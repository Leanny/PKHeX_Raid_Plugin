using System;
using System.Buffers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using static PKHeX_Raid_Plugin.SwitchCommand;

namespace PKHeX_Raid_Plugin;

public class SwitchWifiConnection : ISwitchConnection
{
    private Socket _socket;
    private bool _lastKnownConnectionStatus;
    public bool IsConnected => _socket?.Connected ?? false;

    public event Action<bool>? ConnectionStatusChanged;
    private int MaximumTransferSize { get; set; } = 0x1C0;
    private int BaseDelay { get; set; } = 64;
    private int DelayFactor { get; set; } = 256;

    public string Name = "Wifi";

    public async Task<bool> GetConnectionAsync(string host, int port, int timeoutMs = 5000)
    {
        using var cts = new CancellationTokenSource(timeoutMs);
        _socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        await Task.Delay(1000);
        try
        {
            await _socket.ConnectAsync(host, port, cts.Token).ConfigureAwait(false);
            UpdateConnectionStatus(_socket.Connected);
            return _socket.Connected;
        }
        catch (Exception ex)
        {
            Log($"Connection failed: {ex.Message}");
            return false;
        }
    }

    private void UpdateConnectionStatus(bool currentStatus)
    {
        if (currentStatus == _lastKnownConnectionStatus) return;
         _lastKnownConnectionStatus = currentStatus;
            ConnectionStatusChanged?.Invoke(currentStatus);          
    }

    private async Task<bool> SendDataAsync(byte[] buffer, CancellationToken token)
    {
        UpdateConnectionStatus(_socket?.Connected ?? false);
        if (_socket == null || !_socket.Connected)
        {
            Log("Not connected to the Switch.");
            return false;
        }

        try
        {
            await _socket.SendAsync(buffer, token).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Log($"Send failed: {ex.Message}");
        }
        return true;
    }

    private async Task<int> ReceiveDataAsync(Memory<byte> buffer, CancellationToken token)
    {
        UpdateConnectionStatus(_socket?.Connected ?? false);
        if (_socket == null || !_socket.Connected)
        {
            Log("Not connected to the Switch.");
            return 0;
        }

        try
        {
            return await _socket.ReceiveAsync(buffer, token).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Log($"Receive failed: {ex.Message}");
            return 0;
        }
    }

    public void Disconnect()
    {
        if (_socket == null || !_socket.Connected)
        {
            Log("Already disconnected from the Switch.");
            return;
        }

        try
        {
            _socket?.Disconnect(false);
            UpdateConnectionStatus(false);
        }
        catch (Exception ex)
        {
            Log($"Disconnection failed: {ex.Message}");
        }
    }
    public async Task<byte[]> ReadBytesAsync(uint offset, int length, CancellationToken token)
    {
        if (!IsConnected)
        {
            Log("Not connected to the Switch.");
            return [];
        }

        if (length <= MaximumTransferSize)
        {
            var data = Peek(offset, length);
            return await ReadBytesFromCmdAsync(data, length, token).ConfigureAwait(false);
        }

        byte[] result = new byte[length];
        for (int i = 0; i < length; i += MaximumTransferSize)
        {
            int len = MaximumTransferSize;
            int delta = length - i;
            if (delta < MaximumTransferSize)
                len = delta;

            var data = Peek(offset + (uint)i, len);
            var bytes = await ReadBytesFromCmdAsync(data, len, token).ConfigureAwait(false);
            bytes.CopyTo(result, i);
            await Task.Delay((MaximumTransferSize / DelayFactor) + BaseDelay, token).ConfigureAwait(false);
        }
        return result;
    }
    private async Task<byte[]> ReadRaw(byte[] command, int length, CancellationToken token)
    {
        try
        {
            await SendDataAsync(command, token).ConfigureAwait(false);
            var buffer = new byte[length];
            await ReceiveDataAsync(buffer, token).ConfigureAwait(false);
            return buffer;
        }
        catch (Exception ex)
        {
            Log($"{nameof(ReadRaw)} failed: {ex.Message}");
            return [];
        }
    }

    public async Task WriteBytesAsync(byte[] data, uint offset, CancellationToken token)
    {
        if (!IsConnected)
        {
            Log("Not connected to the Switch.");
            return;
        }

        if (data.Length <= MaximumTransferSize)
        {
            var cmd = Poke(offset, data);
            await SendDataAsync(cmd, token).ConfigureAwait(false);
            return;
        }
        int byteCount = data.Length;
        for (int i = 0; i < byteCount; i += MaximumTransferSize)
        {
            var length = byteCount - i;
            if (length > MaximumTransferSize)
                length = MaximumTransferSize;
            var cmd = GetPoke(data, offset, i, length);
            await SendDataAsync(cmd, token).ConfigureAwait(false);
            await Task.Delay((MaximumTransferSize / DelayFactor) + BaseDelay, token).ConfigureAwait(false);
        }
    }

    private static byte[] GetPoke(byte[] data, uint offset, int i, int length)
    {
        var slice = data.AsSpan(i, length);
        return Poke(offset + (uint)i, slice);
    }

    private async Task<byte[]> ReadBytesFromCmdAsync(byte[] cmd, int length, CancellationToken token)
    {
        try
        {
            await SendDataAsync(cmd, token).ConfigureAwait(false);
            var size = (length * 2) + 1;
            var buffer = ArrayPool<byte>.Shared.Rent(size);
            try
            {
                var mem = buffer.AsMemory()[..size];
                await ReceiveDataAsync(mem, token).ConfigureAwait(false);
                return DecodeResult(mem, length);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer, true);
            }
        }
        catch (Exception ex)
        {
            Log($"{nameof(ReadBytesFromCmdAsync)} failed: {ex.Message}");
            return [];
        }
    }

    private static byte[] DecodeResult(ReadOnlyMemory<byte> buffer, int length)
    {
        try
        {
            var result = new byte[length];
            if (buffer.Length < 1)
                return [];
            var span = buffer.Span[..^1]; // Last byte is always a terminator
            LoadHexBytesTo(span, result);
            return result;
        }
        catch (Exception)
        {
            return [];
        }
    }

    public async Task<string> GetTitleID(CancellationToken token)
    {
        try
        {
            var bytes = await ReadRaw(SwitchCommand.GetTitleID(), 17, token).ConfigureAwait(false);
            if (bytes.Length == 0)
            {
                Log($"{nameof(GetTitleID)}: Invalid response");
                return string.Empty;
            }
            return Encoding.ASCII.GetString(bytes).Trim();
        }
        catch (Exception ex)
        {
            Log($"{nameof(GetTitleID)} failed: {ex.Message}");
            return string.Empty;
        }
    }

    public async Task<string> GetBotbaseVersion(CancellationToken token)
    {
        try
        {
            // Allows up to 9 characters for version, and trims extra '\0' if unused.
            var bytes = await ReadRaw(SwitchCommand.GetBotbaseVersion(), 10, token).ConfigureAwait(false);
            if (bytes.Length == 0)
            {
                Log($"{nameof(GetBotbaseVersion)}: Invalid response");
                return string.Empty;
            }
            return Encoding.ASCII.GetString(bytes).Trim('\0');
        }
        catch (Exception ex)
        {
            Log($"{nameof(GetBotbaseVersion)} failed: {ex.Message}");
            return string.Empty;
        }
    }

    public async Task<string> GetGameInfo(string info, CancellationToken token)
    {
        try
        {
            var bytes = await ReadRaw(SwitchCommand.GetGameInfo(info), 17, token).ConfigureAwait(false);
            if (bytes.Length == 0)
            {
                Log($"{nameof(GetGameInfo)}: Invalid response");
                return string.Empty;
            }
            return Encoding.ASCII.GetString(bytes).Trim('\0', '\n');
        }
        catch (Exception ex)
        {
            Log($"{nameof(GetGameInfo)} failed: {ex.Message}");
            return string.Empty;
        }
    }

    public void Log(string message) => LogUtil.LogInfo(message, Name);
    public void Dispose()
    {
        _socket?.Close();
        _socket?.Dispose();
    }
}
