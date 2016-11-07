using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public interface IClient
    {
        string ip { get; }
        int port { get; }
        bool Connect(string ip, int port);
        bool Disconnect();
        string[] Read();
        void Send(IMessage msg);
    }

