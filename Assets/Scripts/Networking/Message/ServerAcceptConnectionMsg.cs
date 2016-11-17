using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class ServerAcceptConnectionMsg:Message
    {
    public ushort Clientid { get; private set; }
    //tworze wiadomosc do wyslania 
    public ServerAcceptConnectionMsg(ushort id )
    {
        this.Clientid = id;
        this.subject = MessageSubject.ServerAcceptConnection;
    }
    // wiadomosc odbieram, nie wiem jaki typ i go parsuje 
    public ServerAcceptConnectionMsg(IMessage msg)
    {
        this.subject = msg.subject;
        this.raw = msg.raw;
        this.Clientid = ushort.Parse(raw[1]);
    }
    public override string GetData()
    {
        return Clientid.ToString();
    }
}
public class DisconnectMessage : ServerAcceptConnectionMsg
{
    public DisconnectMessage(ushort clientID) : base(clientID)
    {
        this.subject = MessageSubject.ClientDisconnect;
    }
    public DisconnectMessage(IMessage msg) : base(msg) { }
}