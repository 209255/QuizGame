    class ScoreMsg:Message
    {
    public ushort Clientid { get; private set; }
    public int ClientScore { get; private set; }
    public ScoreMsg(ushort Clientid,int Clientscore)
    {
        this.Clientid = Clientid;
        this.ClientScore = Clientscore;
        this.subject = MessageSubject.Score;
    }
    public ScoreMsg(IMessage msg)
    {
        this.subject = msg.subject;
        this.raw = msg.raw;
        string[] data = raw[1].Split(MessageSeparators.dataSeparator);
        this.Clientid = ushort.Parse(data[0]);
        this.ClientScore = int.Parse(data[1]);
    }
    public override string GetData()
    {
        return Clientid.ToString() + MessageSeparators.dataSeparator + ClientScore.ToString();
    }

}

