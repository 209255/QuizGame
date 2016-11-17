using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


     public interface IServiceCommunication
    {
        void Send(IMessage msg);
        event Action<IMessage> Received;
        bool RegisterCallback(MessageSubject subject, Action<IMessage> callback);
        bool UnregisterCallback(MessageSubject subject, Action<IMessage> callback);
    }

