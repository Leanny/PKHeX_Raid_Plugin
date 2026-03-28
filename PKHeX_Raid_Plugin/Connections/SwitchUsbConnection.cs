using LibUsbDotNet;
using LibUsbDotNet.Main;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static PKHeX_Raid_Plugin.SwitchCommand;

namespace PKHeX_Raid_Plugin;

public class SwitchUsbConnection : ISwitchConnection
{
    public string Name = "Usb";
    private bool _lastKnownConnectionStatus;
    public bool IsConnected { get; protected set; }
    public event Action<bool>? ConnectionStatusChanged;
    private int _port;

    private UsbDevice? SwDevice;
    private UsbEndpointReader? reader;
    private UsbEndpointWriter? writer;

    public int MaximumTransferSize { get; set; } = 0x1C0;
    public int BaseDelay { get; set; } = 1;
    public int DelayFactor { get; set; } = 1000;

    private readonly Lock _sync = new();
    private static readonly Lock _registry = new();

    public async Task<bool> GetConnectionAsync(string host, int port, int timeout)
    {
        _port = port;
        SwDevice = TryFindUSB() ?? throw new Exception("USB device not found.");
        if (SwDevice is not IUsbDevice usb)
        {
            UpdateConnectionStatus(false);
            throw new Exception("Device is using a WinUSB driver. Use libusbK and create a filter.");
        }

        bool resagain = false;
        lock (_sync)
        {
            // UsbRegistryInfo is only supported on Windows.
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && !usb.UsbRegistryInfo!.IsAlive)
                usb.ResetDevice();

            if (usb.IsOpen)
                usb.Close();
            usb.Open();

            usb.SetConfiguration(1);
            resagain = usb.ClaimInterface(0);
            if (!resagain)
            {
                usb.ReleaseInterface(0);
                usb.ClaimInterface(0);
            }

            reader = SwDevice.OpenEndpointReader(ReadEndpointID.Ep01);
            writer = SwDevice.OpenEndpointWriter(WriteEndpointID.Ep01);
        }
        UpdateConnectionStatus(resagain);
        return IsConnected = resagain;
    }

    private UsbDevice? TryFindUSB()
    {
        lock (_registry)
        {
            foreach (var device in UsbDevice.AllLibUsbDevices)
            {
                if (device is not UsbRegistry ur)
                    continue;
                if (ur.Vid != 0x057E)
                    continue;
                if (ur.Pid != 0x3000)
                    continue;

                // Only Windows supports reading the port number from the registry.
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    ur.DeviceProperties.TryGetValue("Address", out var addr);
                    if (_port.ToString() != addr?.ToString())
                        continue;
                }

                return ur.Device;
            }
        }
        return null;
    }

    public void Disconnect()
    {
        lock (_sync)
        {
            if (SwDevice is { IsOpen: true } x)
            {
                if (x is IUsbDevice wholeUsbDevice)
                {
                    if (!wholeUsbDevice.UsbRegistryInfo.IsAlive)
                        wholeUsbDevice.ResetDevice();
                    wholeUsbDevice.ReleaseInterface(0);
                }
                x.Close();
            }

            Dispose();
            UpdateConnectionStatus(false);
            IsConnected = false;
        }
    }

    private int Send(byte[] buffer)
    {
        lock (_sync)
            return SendInternal(buffer);
    }

    private int Read(byte[] buffer)
    {
        lock (_sync)
            return ReadInternal(buffer);
    }

    public Task<string> GetTitleID(CancellationToken token)
    {
        return Task.Run<string>(() =>
        {
            Send(SwitchCommand.GetTitleID(false));
            byte[] baseBytes = ReadBulkUSB();
            if (baseBytes.Length == 0)
            {
                Log($"{nameof(GetTitleID)}: Invalid response");
                return string.Empty;
            }
            return BitConverter.ToUInt64(baseBytes, 0).ToString("X16").Trim();
        }, token);
    }

    public Task<string> GetBotbaseVersion(CancellationToken token)
    {
        return Task.Run<string>(() =>
        {
            Send(SwitchCommand.GetBotbaseVersion(false));
            byte[] baseBytes = ReadBulkUSB();
            if (baseBytes.Length == 0)
            {
                Log($"{nameof(GetBotbaseVersion)}: Invalid response");
                return string.Empty;
            }
            return Encoding.UTF8.GetString(baseBytes).Trim('\0');
        }, token);
    }

    public Task<string> GetGameInfo(string info, CancellationToken token)
    {
        return Task.Run<string>(() =>
        {
            Send(SwitchCommand.GetGameInfo(info, false));
            byte[] baseBytes = ReadBulkUSB();
            if (baseBytes.Length == 0)
            {
                Log($"{nameof(GetGameInfo)}: Invalid response");
                return string.Empty;
            }
            return Encoding.UTF8.GetString(baseBytes).Trim('\0');
        }, token);
    }

    public async Task<byte[]> ReadBytesAsync(uint offset, int length, CancellationToken token)
    {
        var cmd = Peek(offset, length, false);
        SendInternal(cmd);
        return ReadBulkUSB();
    }

    protected byte[] ReadBulkUSB()
    {
        // Give it time to push back.
        Thread.Sleep(1);

        lock (_sync)
        {
            try
            {
                if (reader == null)
                    throw new Exception("USB device not found or not connected.");

                // Let usb-botbase tell us the response size.
                byte[] sizeOfReturn = new byte[4];
                var ec = reader.Read(sizeOfReturn, 5000, out int ret);
                if (ec != ErrorCode.None && ret == 0)
                    throw new Exception(UsbDevice.LastErrorString);

                int size = BitConverter.ToInt32(sizeOfReturn, 0);
                byte[] buffer = new byte[size];

                // Loop until we have read everything.
                int transfSize = 0;
                while (transfSize < size)
                {
                    Thread.Sleep(1);
                    ec = reader.Read(buffer, transfSize, Math.Min(reader.ReadBufferSize, size - transfSize), 5000, out int lenVal);
                    if (ec != ErrorCode.None)
                        throw new Exception(UsbDevice.LastErrorString);

                    transfSize += lenVal;
                }
                return buffer;
            }
            catch (Exception ex)
            {
                // Win32Error is returned when the device aborts a transfer, which happens when, for example, readMem() is called with an invalid address.
                // As such, we ignore it to avoid log spam but still return a zero-buffer to avoid crashing the caller, and to maintain connection.
                var lastError = UsbDevice.LastErrorNumber;
                if (lastError is not (int)ErrorCode.Win32Error)
                    Log($"{nameof(ReadBulkUSB)} failed: {ex.Message}");
                return [0];
            }
        }
    }
    public async Task WriteBytesAsync(byte[] data, uint offset, CancellationToken token)
    {
        if (data.Length > MaximumTransferSize)
            WriteLarge(data, offset);
        else
            WriteSmall(data, offset);
    }

    private void WriteSmall(ReadOnlySpan<byte> data, uint offset)
    {
        lock (_sync)
        {
            var cmd = Poke(offset, data, false);
            SendInternal(cmd);
            Thread.Sleep(1);
        }
    }
    private void WriteLarge(ReadOnlySpan<byte> data, uint offset)
    {
        while (data.Length != 0)
        {
            var length = Math.Min(data.Length, MaximumTransferSize);
            var slice = data[..length];
            WriteSmall(slice, offset);

            data = data[length..];
            offset += (uint)length;
            Thread.Sleep((MaximumTransferSize / DelayFactor) + BaseDelay);
        }
    }

    private int ReadInternal(byte[] buffer)
    {
        try
        {
            byte[] sizeOfReturn = new byte[4];
            if (reader == null)
            {
                UpdateConnectionStatus(false);
                throw new Exception("USB device not found or not connected.");
            }
                
            var ec = reader.Read(sizeOfReturn, 5000, out int ret);
            if (ec != ErrorCode.None && ret == 0)
                throw new Exception(UsbDevice.LastErrorString);

            ec = reader.Read(buffer, 5000, out var lenVal);
            if (ec != ErrorCode.None)
                throw new Exception(UsbDevice.LastErrorString);

            return lenVal;
        }
        catch (Exception ex)
        {
            // Win32Error is returned when the device aborts a transfer, which happens when, for example, readMem() is called with an invalid address.
            // As such, we ignore it to avoid log spam, log other exceptions, and return 0 to maintain connection.
            var lastError = UsbDevice.LastErrorNumber;
            if (lastError is not (int)ErrorCode.Win32Error)
                Log($"{nameof(ReadInternal)} failed: {ex.Message}");
            return 0;
        }
    }

    private int SendInternal(byte[] buffer)
    {
        try
        {
            if (writer == null)
            {
                UpdateConnectionStatus(false);
                throw new Exception("USB device not found or not connected.");
            }

            uint pack = (uint)buffer.Length + 2;
            var ec = writer.Write(BitConverter.GetBytes(pack), 2000, out int ret);
            if (ec != ErrorCode.None && ret == 0)
                throw new Exception(UsbDevice.LastErrorString);

            ec = writer.Write(buffer, 2000, out var l);
            if (ec != ErrorCode.None)
                throw new Exception(UsbDevice.LastErrorString);

            return l;
        }
        catch (Exception ex)
        {
            // Win32Error is returned when the device aborts a transfer, which happens when, for example, readMem() is called with an invalid address.
            // As such, we ignore it to avoid log spam, log other exceptions, and return 0 to maintain connection.
            var lastError = UsbDevice.LastErrorNumber;
            if (lastError is not (int)ErrorCode.Win32Error)
                Log($"{nameof(SendInternal)} failed: {ex.Message}");
            return 0;
        }
    }

    private void UpdateConnectionStatus(bool currentStatus)
    {
        if (currentStatus == _lastKnownConnectionStatus) return;
        _lastKnownConnectionStatus = currentStatus;
        ConnectionStatusChanged?.Invoke(currentStatus);
    }

    public void Log(string message) => LogUtil.LogInfo(message, Name);

    public void Dispose()
    {
        reader?.Dispose();
        writer?.Dispose();
    }
}
