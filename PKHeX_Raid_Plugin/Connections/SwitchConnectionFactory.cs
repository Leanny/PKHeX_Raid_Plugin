using System;
using System.Collections.Generic;
using System.Text;

namespace PKHeX_Raid_Plugin
{
    public static class SwitchConnectionFactory
    {
        public static ISwitchConnection CreateConnection(ConnectionType type)
        {
            return type switch
            {
                // ConnectionType.USB => new SwitchUsbConnection(), TODO: Implement USB connection
                ConnectionType.WiFi => new SwitchWifiConnection(),
                _ => throw new ArgumentException("Invalid connection type", nameof(type)),
            };
        }
    }
}
