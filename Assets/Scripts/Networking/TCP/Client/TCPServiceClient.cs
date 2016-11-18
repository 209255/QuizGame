using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class TCPServiceClient :ITCPServiceClient
    {
        private IClient client;
        public IRegister<MessageSubject, Action<IMessage>> callbackRegister;
        public event Action<IMessage> Received;
        public Action OnIdFromServer { get; set; }
        public ushort id { get; private set; }
        public string Ip { get { return client.ip; } }
        public int Port { get { return client.port; } }

        public TCPServiceClient()
        {
            this.client = new Client();
            callbackRegister = new Register<MessageSubject, Action<IMessage>>();
            RegisterCallback(MessageSubject.ServerAcceptConnection, AccepctIdFromServer);
        }

        private void AccepctIdFromServer(IMessage message)
        {
            ServerAcceptConnectionMsg msg = new ServerAcceptConnectionMsg(message);
            this.id = msg.Clientid;
            OnIdFromServer();
        }

        private void NotifyMyDisconnect()
        {
            DisconnectMessage msg = new DisconnectMessage(id);
            client.Send(msg);
        }

        public bool RegisterCallback(MessageSubject subject, Action<IMessage> callback)
        {
            return callbackRegister.RegisterObject(subject, callback);
        }
        public bool UnregisterCallback(MessageSubject subject, Action<IMessage> callback)
        {
            return callbackRegister.UnregisterObject(subject, callback);
        }

        public bool Connect(string ip, int port)
        {
            if (client.Connect(ip, port))
            { 
               return true;
            }
            return false;

        }
        public bool Disconnect()
        {
            NotifyMyDisconnect();
            return client.Disconnect();
        }

        public void Send(IMessage msg)
        {
           client.Send(msg);
        }
        private void Read()
        {
            string[] messages = client.Read();
            foreach (var message in messages)
            {
                var messageObject = new Message(message);
                if (callbackRegister.register.ContainsKey(messageObject.subject))
                    for (int i = 0; i < callbackRegister.register[messageObject.subject].Count; ++i)
                        callbackRegister.register[messageObject.subject][i](messageObject);
            }
        }

}


