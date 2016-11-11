using System;

    public interface IServer
    {
  
    Action<ushort> NewConnection { get; set; }
    void RemoveClient(ushort id);
    void Read();
    void SendTo(ushort id, IMessage msg);
    void Start();
    void Stop();
    }

