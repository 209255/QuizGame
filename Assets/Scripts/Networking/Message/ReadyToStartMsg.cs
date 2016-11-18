using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ReadyToStartMsg : Message
{
    public ushort Clientid { get; private set; }
    public bool ClientReady { get; private set; }
    public ReadyToStartMsg(ushort Clientid, bool isReady)
    {
        this.Clientid = Clientid;
        this.ClientReady = isReady;
        this.subject = MessageSubject.Score;
    }
    public ReadyToStartMsg(IMessage msg)
    {
        this.subject = msg.subject;
        this.raw = msg.raw;
        string[] data = raw[1].Split(MessageSeparators.dataSeparator);
        this.Clientid = ushort.Parse(data[0]);
        this.ClientReady = bool.Parse(data[1]);
    }
    public override string GetData()
    {
        return Clientid.ToString() + MessageSeparators.dataSeparator + ClientReady.ToString();
    }

}