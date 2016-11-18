using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Networking
{
    class TCPServiceServer : ITCPServiceServer
    {
        public event Action<IMessage> Received;

        public void AcceptConnection()
        {
          
        }

        public void AcceptDisconnection()
        {
            throw new NotImplementedException();
        }

        public bool Connect(string ip, int port)
        {
            throw new NotImplementedException();
        }

        public bool Disconnect()
        {
            throw new NotImplementedException();
        }

        public bool RegisterCallback(MessageSubject subject, Action<IMessage> callback)
        {
            throw new NotImplementedException();
        }

        public void Send()
        {
            throw new NotImplementedException();
        }

        public void Send(IMessage msg)
        {
            throw new NotImplementedException();
        }

        public bool UnregisterCallback(MessageSubject subject, Action<IMessage> callback)
        {
            throw new NotImplementedException();
        }
    }
}
