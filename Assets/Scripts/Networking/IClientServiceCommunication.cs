using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



public interface IClientServiceCommunication:IServiceCommunication
    {
    event Action OnIdFromServer;
    bool Connect(string ip,int port);
    bool Disconnect();
    ushort id { get; }
    bool isConnected { get; }

}

