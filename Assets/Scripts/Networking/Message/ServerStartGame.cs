using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class ServerStartGame:Message
    {
    public ushort Clientid { get; private set; }
    public string Category { get; private set; }
    public ServerStartGame(ushort id, string Category)
    {
        this.Clientid = Clientid;
        this.Category = Category;
        this.subject = MessageSubject.ServerStartGame;

    }
    public ServerStartGame(IMessage msg)
    {
        this.subject = msg.subject;
        this.raw = msg.raw;
        string[] data = raw[1].Split(MessageSeparators.dataSeparator);
        this.Clientid = ushort.Parse(data[0]);
        this.Category= data[1].ToString();

    }
    public override string GetData()
    {
        return Clientid.ToString() + MessageSeparators.dataSeparator + Category;
    }
}

