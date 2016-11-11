using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


   public  interface IServerCommunication
    {
        void Read();
        void SendTo(ushort id, IMessage msg);
        void SendToAll(IMessage msg);
    }
