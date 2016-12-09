using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public interface ITCPServiceServer
    {
    void Broadcast(IMessage msg);
    void ExecuteCallbacks(ushort id, IMessage message);
    void RegisterCallback(MessageSubject subject, Action<IMessage> callback);
    void UnregisterCallback(MessageSubject subject, Action<IMessage> callback);
    void SendTo(ushort id, IMessage msg);
    void SendToOthers(ushort id, IMessage msg);
    void Start();
    void Stop();
    void RemoveClient(ushort id);
    }

