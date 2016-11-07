using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Networking
{
    class BluetoothServiceServer : IBluetoothServiceServer
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

        public bool UnregisterCallback(MessageSubject subject, Action<IMessage> callback)
        {
            throw new NotImplementedException();
        }
    }
}
