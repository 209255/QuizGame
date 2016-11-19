using System;

    public interface IServer
    {
  
    Action<ushort> NewConnection { get; set; }
    NewMessage NewMessage { get; set; }
    void RemoveClient(ushort id);
    void Read();
    void Broadcast(IMessage msg);
    void SendToOthers(ushort Id, IMessage msg);
    void SendTo(ushort id, IMessage msg);
    void Start();
    void Stop();
    }

