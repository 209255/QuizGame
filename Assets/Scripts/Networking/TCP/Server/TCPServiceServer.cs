using System;

    class TCPServiceServer : ITCPServiceServer
    {

        IRegister<MessageSubject, Action<ushort, IMessage>> callbackRegister;
        IServer server;
        public TCPServiceServer(IServer server)
        {
            this.server = server;
            server.NewConnection += AssignId;
            callbackRegister = new Register<MessageSubject, Action<ushort, IMessage>>();
            server.NewMessage += ExecuteCallbacks;
        }
        
        private void onDisconnect(ushort clientId, IMessage message)
        {
            DisconnectMessage msg = new DisconnectMessage(message);
            server.RemoveClient(msg.Clientid);
            SendToOthers(msg.Clientid, msg);
            // Log.Print("Klient" + msg.clientId + "opuscil server");
        }
        public bool Connect(string ip, int port)
        {
            throw new NotImplementedException();
        }

        public void ExecuteCallbacks(ushort id, IMessage message)
        {
            if (callbackRegister.register.ContainsKey(message.subject))
                foreach (var action in callbackRegister.register[message.subject])
                    action(id, message);
        }

        public void RegisterCallback(MessageSubject subject, Action<ushort,IMessage> callback)
        {
            callbackRegister.RegisterObject(subject, callback);
        }
        public void UnregisterCallback(MessageSubject subject, Action<ushort,IMessage> callback)
        {
        callbackRegister.UnregisterObject(subject, callback);
        }
        public void Broadcast(IMessage msg)
        {
            server.Broadcast(msg);
        }
        public void SendTo(ushort id, IMessage msg)
        {
            server.SendTo(id, msg);
        }
        public void SendToOthers(ushort id, IMessage msg)
        {
            server.SendToOthers(id, msg);
        }
        public void Start()
        {
            server.Start();
            /// Log.Print("Serwer wystartował");
        }
        public void Stop()
        {
            server.Stop();
            //Log.Print("Serwer został wyłączony");
        }
        public void RemoveClient(ushort id)
        {
            server.RemoveClient(id);
        }
        private void Read()
        {
            server.Read();
        }
        private void AssignId(ushort clientId)
        {
            ServerAcceptConnectionMsg msg = new ServerAcceptConnectionMsg(clientId);
            server.SendTo(clientId, msg);
            //  Log.Print("Pojawił się nowy klient o id : " + clientId);
        }
}

