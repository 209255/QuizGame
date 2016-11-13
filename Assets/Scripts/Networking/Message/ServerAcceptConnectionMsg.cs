using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class ServerAcceptConnectionMsg:Message
    {
    public ushort id { get; private set; }
    //tworze wiadomosc do wyslania 
    public ServerAcceptConnectionMsg(ushort id )
    {
        this.id = id;
        this.subject = MessageSubject.ServerAcceptConnection;
    }
    // wiadomosc odbieram, nie wiem jaki typ i go parsuje 
    public ServerAcceptConnectionMsg(IMessage msg)
    {
        this.subject = msg.subject;
        this.raw = msg.raw;
        this.id = ushort.Parse(raw[1]);
    }
    public override string GetData()
    {
        return id.ToString();
    }
}

