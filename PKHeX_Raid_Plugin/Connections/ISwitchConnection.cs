using PKHeX.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PKHeX_Raid_Plugin
{
    public interface ISwitchConnection : IDisposable
    {
        bool IsConnected { get; }
        event Action<bool>? ConnectionStatusChanged;
        Task<bool> GetConnectionAsync(string host, int port, int timeout);
        void Disconnect();
        Task<string> GetGameInfo(string info, CancellationToken token);
        Task<string> GetBotbaseVersion(CancellationToken token);
        Task<string> GetTitleID(CancellationToken token);
        Task WriteBytesAsync(byte[] data, uint offset, CancellationToken token);
        Task<byte[]> ReadBytesAsync(uint offset, int length, CancellationToken token);
        void Log(string message);
    }
}
