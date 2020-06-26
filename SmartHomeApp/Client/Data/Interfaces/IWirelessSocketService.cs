using SmartHomeApp.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeApp.Client.Data.Interfaces
{
    public interface IWirelessSocketService
    {
        List<BaseSocket> GetWirelessSockets();
        BaseSocket GetWirelessSocketByName(string name);
        BaseSocket AddWirelessSocket(BaseSocket wirelessSocket);
        BaseSocket UpdateWirelessSocket(string name, BaseSocket wirelessSocket);
        void DeleteWirelessSocket(string name);
        Task<bool> ToggleWirelessSocketState(BaseSocket wirelessSocket);
    }
}
