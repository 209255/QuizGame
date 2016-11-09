using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Message:IMessage
    {
    private readonly char messageSeparator = ';';
        public MessageSubject subject { get; private set; }
        public string[] raw { get; private set; }
        public int Senderid { get; set; }
    Message(byte[] data)
    {

    }
    public Message(string msg)
    {
        raw = msg.Split(messageSeparator);
        subject = (MessageSubject)ushort.Parse(raw[0]);
        
    }
    public override string ToString()
    {
        return ((int)subject).ToString()+messageSeparator+Senderid.ToString()+GetData();
    }
    public virtual string GetData()
    {
        return raw[1];
    }
    }

