using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class MessageSeparators
{
    public const char messageSeparator = ';';
    public const char endOfTCPMessageSeparator = '^';
    public const char dataSeparator = ':';
}

class Message:IMessage
    {
    
        public MessageSubject subject { get; protected set; }
        public string[] raw { get; protected set; }
        public int Senderid { get; set; }
    Message(byte[] data)
    {

    }
    public Message()
    {


    }
    public Message(string msg)
    {
        raw = msg.Split(MessageSeparators.messageSeparator);
        subject = (MessageSubject)ushort.Parse(raw[0]);
        
    }
    public override string ToString()
    {
        return ((int)subject).ToString()+ MessageSeparators.messageSeparator + Senderid.ToString()+GetData();
    }
    public virtual string GetData()
    {
        return raw[1];
    }
    }

