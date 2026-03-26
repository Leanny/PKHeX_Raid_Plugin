using System;
using System.Threading;
using System.Threading.Tasks;

namespace PKHeX_Raid_Plugin
{
    public interface ISwitchConnection : IDisposable
    {
        bool IsConnected { get; }
        Task<bool> GetConnectionAsync(string indentifier, int port, int timeout);
        Task<bool> SendDataAsync(byte[] data, CancellationToken token);
        Task<int> ReceiveDataAsync(Memory<byte> buffer, CancellationToken token);
        void Disconnect();
        bool CloseIt();
    }
}
