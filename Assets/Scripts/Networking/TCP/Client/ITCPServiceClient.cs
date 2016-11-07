using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


   public interface ITCPServiceClient:ICommunnication
    {
        string Ip { get;}
        ushort id { get; }
        int Port { get; }
        bool Connect(string ip,int port);
        bool Disconnect();
    }

