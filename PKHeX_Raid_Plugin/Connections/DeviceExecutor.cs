using PKHeX.Core;
using SysBot.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PKHeX_Raid_Plugin.Connections
{
    public enum RoutineType
    {
        None,
        ReadWrite,
    }

    public class DeviceState : BotState<RoutineType, SwitchConnectionConfig>
    {
        public override void IterateNextRoutine() => CurrentRoutineType = NextRoutineType;
        public override void Initialize() => Resume();
        public override void Pause() => NextRoutineType = RoutineType.None;
        public override void Resume() => NextRoutineType = InitialRoutine;

    }

    public class DeviceExecutor(DeviceState cfg) : SwitchRoutineExecutor<DeviceState>(cfg)
    { 
        public const decimal BotbaseVersion = 2.4m;
        private const string VersionNumber = "1.3.2";
        private const string SwordID = "0100ABF008968000";
        private const string ShieldID = "01008DB008C2C000";

        public override string GetSummary()
        {
            var current = Config.CurrentRoutineType;
            var initial = Config.InitialRoutine;
            if (current == initial)
                return $"{Connection.Label} - {initial}";
            return $"{Connection.Label} - {initial} ({current})";
        }

        public override void SoftStop() => Config.Pause();
        public override Task HardStop() => Task.CompletedTask;

        public override async Task MainLoop(CancellationToken token)
        {
            var botbase = await VerifyBotbaseVersion(token).ConfigureAwait(false);
            Log($"Valid Botbase Version: {botbase}");
            var game = await ReadGame(token).ConfigureAwait(false);
            Log($"Valid Title ID ({(game is GameVersion.SW ? $"{SwordID}" : $"{ShieldID}")})");
            var version = await ReadGameVersion(token).ConfigureAwait(false);
            Log($"Valid Game Version: {version}");
            Log("Connection Test OK");
            Config.IterateNextRoutine();        
        }

        public async Task Connect(CancellationToken token)
        {
            Connection.Connect();
            Log("Initializing connection with console...");
            await InitialStartup(token).ConfigureAwait(false);
        }

        public void Disconnect()
        {
            HardStop();
            Connection.Disconnect();
        }

        //Thanks Anubis
        //https://github.com/kwsch/SysBot.NET/blob/b26c8c957364efe316573bec4b82e8c5c5a1a60f/SysBot.Pokemon/Actions/PokeRoutineExecutor.cs#L88
        //AGPL v3 License
        public async Task<string> VerifyBotbaseVersion(CancellationToken token)
        {
            if (Config.Connection.Protocol is SwitchProtocol.WiFi && !Connection.Connected)
                throw new InvalidOperationException("No remote connection");

            var data = await SwitchConnection.GetBotbaseVersion(token).ConfigureAwait(false);
            var version = decimal.TryParse(data, CultureInfo.InvariantCulture, out var v) ? v : 0;
            if (version < BotbaseVersion)
            {
                var protocol = Config.Connection.Protocol;
                var msg = protocol is SwitchProtocol.WiFi ? "sys-botbase" : "usb-botbase";
                msg += $" version is not supported. Expected version {BotbaseVersion} or greater, and current version is {version}. Please download the latest version from: ";
                if (protocol is SwitchProtocol.WiFi)
                    msg += "https://github.com/olliz0r/sys-botbase/releases/latest";
                else
                    msg += "https://github.com/Koi-3088/usb-botbase/releases/latest";
                throw new Exception(msg);
            }
            return data;
        }

        public async Task<GameVersion> ReadGame(CancellationToken token)
        {
            if (Config.Connection.Protocol is SwitchProtocol.WiFi && !Connection.Connected)
                throw new InvalidOperationException("No remote connection");

            var title = await SwitchConnection.GetTitleID(token).ConfigureAwait(false);

            if (title.Equals(SwordID))
                return GameVersion.SW;
            else if (title.Equals(ShieldID))
                return GameVersion.SH;
            else throw new ArgumentOutOfRangeException($"Invalid Title ID ({title})");
        }

        //Thanks Anubis
        //https://github.com/kwsch/SysBot.NET/blob/b26c8c957364efe316573bec4b82e8c5c5a1a60f/SysBot.Pokemon/SV/PokeRoutineExecutor9SV.cs#L83C19-L83C19
        //AGPL v3 License
        public async Task<string> ReadGameVersion(CancellationToken token)
        {
            if (Config.Connection.Protocol is SwitchProtocol.WiFi && !Connection.Connected)
                throw new InvalidOperationException("No remote connection");

            var version = await SwitchConnection.GetGameInfo("version", token).ConfigureAwait(false);

            if (!version.SequenceEqual(VersionNumber))
                throw new Exception($"Game version is not supported. Expected version {VersionNumber}, and current game version is {version}.");

            return version;
        }

        public async Task<byte[]> GetBytes(BlockDefinition blockDefinition, CancellationToken token)
        {
            var length = blockDefinition.Size;
            var offset = blockDefinition.Offset;
            byte[] data = [];
            if (offset < uint.MaxValue)                
              data = await SwitchConnection.ReadBytesAsync((uint)offset, length, token);              
            return data;
        }

        public async Task WriteBlock(byte[] data, BlockDefinition blockDefinition, CancellationToken token)
        {
            var offset = blockDefinition.Offset;
            if (offset < uint.MaxValue)
            await SwitchConnection.WriteBytesAsync(data, (uint)offset, token);
            return;
        }
    }
}
