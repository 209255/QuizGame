using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



   interface ICommunnication
    {
       void Send();
       event Action<IMessage> Received;
    // IRegister<MessageSubject, Action<IMessage>> callbackRegister { get; };
       bool RegisterCallback(MessageSubject subject, Action<IMessage> callback);
       bool UnregisterCallback(MessageSubject subject, Action<IMessage> callback);

}

