using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


   public interface ITCPServiceClient:IClientServiceCommunication
    {
        string Ip { get;}
        ushort id { get; }
        int Port { get; }
      
    }

