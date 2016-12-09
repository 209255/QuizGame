using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class BluetoothServiceClient : IBluetoothServiceClient
    {
        public IRegister<MessageSubject, Action<IMessage>> callbackRegister
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ushort id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

    public bool isConnected
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public event Action OnIdFromServer;
    public event Action<IMessage> Received;

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

