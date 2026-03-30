using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PKHeX.Core;
using static PKHeX_Raid_Plugin.SwitchCommand;

namespace PKHeX_Raid_Plugin;

public class SwitchConnectionService(ConnectionType type)
{
    private readonly ISwitchConnection _connection = type switch
    {  
        ConnectionType.WiFi => new SwitchWifiConnection(),
        ConnectionType.USB => new SwitchUsbConnection(),
        _ => throw new ArgumentException("Invalid connection type", nameof(type))
    };

    public event Action<bool>? ConnectionStatusChanged
    {
        add => _connection.ConnectionStatusChanged += value;
        remove => _connection.ConnectionStatusChanged -= value;
    }

    public bool IsConnected => _connection.IsConnected;
    private readonly ConnectionType _Type = type;
    public async Task<bool> GetConnectionAsync(string host, int port, int timeoutMs = 3000)
    {
        if (_Type is ConnectionType.WiFi)
            port = 6000;

       var connection = await _connection.GetConnectionAsync(host, port, timeoutMs);
        if (connection)
        {
            try
            {
                await InitialCheck(CancellationToken.None).ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                Log($"Initial check failed: {ex.Message}");
                Disconnect();
                return false;
            }
        }
        return false;
    }

    public async Task<byte[]> GetBytes(BlockDefinition blockDefinition, CancellationToken token)
    {
        var length = blockDefinition.Size;
        var offset = blockDefinition.Offset;
        byte[] data = [];
        if (offset < uint.MaxValue)
            data = await _connection.ReadBytesAsync((uint)offset, length, token);
        return data;
    }

    public async Task WriteBlock(byte[] data, BlockDefinition blockDefinition, CancellationToken token)
    {
        var offset = blockDefinition.Offset;
        if (offset < uint.MaxValue)
            await _connection.WriteBytesAsync(data, (uint)offset, token);
        return;
    }

    public void Disconnect()
    {
        _connection?.Disconnect();
        _connection?.Dispose();
    }

    private async Task InitialCheck(CancellationToken token)
    {
        var botbase = await VerifyBotbaseVersion(token).ConfigureAwait(false);
        Log($"Valid Botbase Version: {botbase}");
        var game = await ReadGame(token).ConfigureAwait(false);
        Log($"Valid Title ID ({(game is GameVersion.SW ? $"{SwordID}" : $"{ShieldID}")})");
        var version = await ReadGameVersion(token).ConfigureAwait(false);
        Log($"Valid Game Version: {version}");
        Log("Connection Test OK");
    }

    private async Task<string> VerifyBotbaseVersion(CancellationToken token)
    {
        if (!IsConnected)
            throw new InvalidOperationException("No remote connection");

        var data = await _connection.GetBotbaseVersion(token).ConfigureAwait(false);
        var version = decimal.TryParse(data, CultureInfo.InvariantCulture, out var v) ? v : 0;
        if (version < BotbaseVersion)
        {
            var msg = $"sys-botbase version is not supported. Expected version {BotbaseVersion} or greater, and current version is {version}. Please download the latest version from: ";
            msg += "https://github.com/olliz0r/sys-botbase/releases/latest";
            throw new Exception(msg);
        }
        return data;
    }

    public async Task<GameVersion> ReadGame(CancellationToken token)
    {
        if (!IsConnected)
            throw new InvalidOperationException("No remote connection");

        var title = await _connection.GetTitleID(token).ConfigureAwait(false);

        if (title.Equals(SwordID))
            return GameVersion.SW;
        else if (title.Equals(ShieldID))
            return GameVersion.SH;
        else throw new ArgumentOutOfRangeException($"Invalid Title ID ({title})");
    }

    private async Task<string> ReadGameVersion(CancellationToken token)
    {
        if (!IsConnected)
            throw new InvalidOperationException("No remote connection");

        var version = await _connection.GetGameInfo("version", token).ConfigureAwait(false);

        if (!version.SequenceEqual(VersionNumber))
            throw new Exception($"Game version is not supported. Expected version {VersionNumber}, and current game version is {version}.");

        return version;
    }

    public void Log(string message) => _connection.Log(message);
}

