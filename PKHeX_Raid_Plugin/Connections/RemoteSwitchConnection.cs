using PKHeX.Core;
using System;
using System.Buffers;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static PKHeX_Raid_Plugin.SwitchCommand;

namespace PKHeX_Raid_Plugin
{
    public class RemoteSwitchConnection : IDisposable
    {
        public bool Connected => _connection.IsConnected;

        private int MaximumTransferSize { get; set; } = 0x1C0;
        private int BaseDelay { get; set; } = 64;
        private int DelayFactor { get; set; } = 256;
        private readonly ISwitchConnection _connection;
        private ConnectionType _connectionType;
        public const decimal BotbaseVersion = 2.4m;
        private const string VersionNumber = "1.3.2";
        private const string SwordID = "0100ABF008968000";
        private const string ShieldID = "01008DB008C2C000";
        private string Label = "";

        public RemoteSwitchConnection(ConnectionType connectionType)
        {
            _connection = SwitchConnectionFactory.CreateConnection(connectionType);
            _connectionType = connectionType;
            Label = connectionType switch
            {
                ConnectionType.WiFi => "Wi-Fi",
                ConnectionType.USB => "USB",
                _ => "Unknown"
            };
        }
        public async Task<bool> GetConnectionAsync(string host, int port, int timeoutMs = 3000)
        {
            Label = _connectionType switch
            {
                ConnectionType.WiFi => $"Wi-Fi-{host}",
                ConnectionType.USB => $"USB-{port}",
                _ => "Unknown"
            };
            return await _connection.GetConnectionAsync(host, port, timeoutMs);
        }

        public void Disconnect() => _connection.Disconnect();

        public async Task InitialCheck(CancellationToken token)
        {
            var botbase = await VerifyBotbaseVersion(token).ConfigureAwait(false);
            Log($"Valid Botbase Version: {botbase}");
            var game = await ReadGame(token).ConfigureAwait(false);
            Log($"Valid Title ID ({(game is GameVersion.SW ? $"{SwordID}" : $"{ShieldID}")})");
            var version = await ReadGameVersion(token).ConfigureAwait(false);
            Log($"Valid Game Version: {version}");
            Log("Connection Test OK");
        }

        public async Task<byte[]> GetBytes(BlockDefinition blockDefinition, CancellationToken token)
        {
            var length = blockDefinition.Size;
            var offset = blockDefinition.Offset;
            byte[] data = [];
            if (offset < uint.MaxValue)
                data = await ReadBytesAsync((uint)offset, length, token);
            return data;
        }

        public async Task WriteBlock(byte[] data, BlockDefinition blockDefinition, CancellationToken token)
        {
            var offset = blockDefinition.Offset;
            if (offset < uint.MaxValue)
                await WriteBytesAsync(data, (uint)offset, token);
            return;
        }

        public async Task<string> VerifyBotbaseVersion(CancellationToken token)
        {
            if (_connectionType is ConnectionType.WiFi && !Connected)
                throw new InvalidOperationException("No remote connection");

            var data = await GetBotbaseVersion(token).ConfigureAwait(false);
            var version = decimal.TryParse(data, CultureInfo.InvariantCulture, out var v) ? v : 0;
            if (version < BotbaseVersion)
            {
                var protocol = _connectionType;
                var msg = protocol is ConnectionType.WiFi ? "sys-botbase" : "usb-botbase";
                msg += $" version is not supported. Expected version {BotbaseVersion} or greater, and current version is {version}. Please download the latest version from: ";
                if (protocol is ConnectionType.WiFi)
                    msg += "https://github.com/olliz0r/sys-botbase/releases/latest";
                else
                    msg += "https://github.com/Koi-3088/usb-botbase/releases/latest";
                throw new Exception(msg);
            }
            return data;
        }

        public async Task<GameVersion> ReadGame(CancellationToken token)
        {
            if (_connectionType is ConnectionType.WiFi && !Connected)
                throw new InvalidOperationException("No remote connection");

            var title = await GetTitleID(token).ConfigureAwait(false);

            if (title.Equals(SwordID))
                return GameVersion.SW;
            else if (title.Equals(ShieldID))
                return GameVersion.SH;
            else throw new ArgumentOutOfRangeException($"Invalid Title ID ({title})");
        }

        public async Task<string> ReadGameVersion(CancellationToken token)
        {
            if (_connectionType is ConnectionType.WiFi && !Connected)
                throw new InvalidOperationException("No remote connection");

            var version = await GetGameInfo("version", token).ConfigureAwait(false);

            if (!version.SequenceEqual(VersionNumber))
                throw new Exception($"Game version is not supported. Expected version {VersionNumber}, and current game version is {version}.");

            return version;
        }


        private async Task<byte[]> ReadBytesAsync(uint offset, int length, CancellationToken token)
        {
            if (!Connected)
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
                await _connection.SendDataAsync(command, token).ConfigureAwait(false);
                var buffer = new byte[length];
                await _connection.ReceiveDataAsync(buffer, token).ConfigureAwait(false);
                return buffer;
            }
            catch (Exception ex)
            {
                Log($"{nameof(ReadRaw)} failed: {ex.Message}");
                return [];
            }
        }

        private async Task WriteBytesAsync(byte[] data, uint offset, CancellationToken token)
        {
            if (!Connected)
            {
                Log("Not connected to the Switch.");
                return;
            }

            if (data.Length <= MaximumTransferSize)
            {
                var cmd = Poke(offset, data);
                await _connection.SendDataAsync(cmd, token).ConfigureAwait(false);
                return;
            }
            int byteCount = data.Length;
            for (int i = 0; i < byteCount; i += MaximumTransferSize)
            {
                var length = byteCount - i;
                if (length > MaximumTransferSize)
                    length = MaximumTransferSize;
                var cmd = GetPoke(data, offset, i, length);
                await _connection.SendDataAsync(cmd, token).ConfigureAwait(false);
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
                await _connection.SendDataAsync(cmd, token).ConfigureAwait(false);
                var size = (length * 2) + 1;
                var buffer = ArrayPool<byte>.Shared.Rent(size);
                try
                {
                    var mem = buffer.AsMemory()[..size];
                    await _connection.ReceiveDataAsync(mem, token).ConfigureAwait(false);
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

        public void Log(string message) => LogInfo(message);
        public void LogInfo(string message) => LogUtil.LogInfo(message, Label);
        public void LogError(string message) => LogUtil.LogError(message, Label);
        public void Dispose() => _connection?.Dispose();
    }
}
