using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class FinishedQuestion:Message
    {
      public ushort Clientid { get; private set; }

     public FinishedQuestion(ushort Clientid)
     {
        this.Clientid = Clientid;

        this.subject = MessageSubject.QuestionFinished;
    }
    public FinishedQuestion(IMessage msg)
    {
        this.subject = msg.subject;
        this.raw = msg.raw;
        string[] data = raw[1].Split(MessageSeparators.dataSeparator);
        this.Clientid = ushort.Parse(data[0]);

    }
    public override string GetData()
    {
        return Clientid.ToString();
    }
}

