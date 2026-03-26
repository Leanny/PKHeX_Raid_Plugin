using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace PKHeX_Raid_Plugin
{
    public class SwitchWifiConnection : ISwitchConnection
    {
        private Socket _socket;
        public bool IsConnected => _socket?.Connected ?? false;
        public async Task<bool> GetConnectionAsync(string host, int port, int timeoutMs = 3000)
        {
            using var cts = new CancellationTokenSource(timeoutMs);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            { NoDelay = true, };

            try
            {
                await _socket.ConnectAsync(host, port, cts.Token).ConfigureAwait(false);
                return _socket?.Connected ?? false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Connection failed: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SendDataAsync(byte[] buffer, CancellationToken token)
        {
            if (_socket == null || !_socket.Connected)  return false;
              Debug.WriteLine("Not connected to the Switch.");
              
            try
            {
                await _socket.SendAsync(buffer, token).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Send failed: {ex.Message}");
            }
                return true;
        }

        public async Task<int> ReceiveDataAsync(Memory<byte> buffer, CancellationToken token)
        {
            if (_socket == null || !_socket.Connected)
            {
                Debug.WriteLine("Not connected to the Switch.");
                return 0;
            }

            try
            {
              return await _socket.ReceiveAsync(buffer, token).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Receive failed: {ex.Message}");
                return 0;
            }
        }

        public void Disconnect()
        {
            try
            {
                _socket?.Disconnect(false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Disconnection failed: {ex.Message}");
            }
        }

        public bool CloseIt()
        {
            if (_socket == null) return true;
            _socket?.Close();
            _socket?.Dispose();
            return true;
        }

        public void Dispose() => CloseIt();

    }
}
