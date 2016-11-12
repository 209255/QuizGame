using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class UDPService : ICommunnication
    {
        public event Action<IMessage> Received;

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

