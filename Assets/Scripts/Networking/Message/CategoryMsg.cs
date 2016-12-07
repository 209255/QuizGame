    class CategoryMsg:Message
    {
        public ushort Clientid { get; private set; }
        public string ClientCategory { get; private set; }
        public CategoryMsg(ushort Clientid, string ClientCategory)
        {
            this.Clientid = Clientid;
            this.ClientCategory = ClientCategory;
            this.subject = MessageSubject.Score;
        }
        public CategoryMsg(IMessage msg)
        {
            this.subject = msg.subject;
            this.raw = msg.raw;
            string[] data = raw[1].Split(MessageSeparators.dataSeparator);
            this.Clientid = ushort.Parse(data[0]);
            this.ClientCategory = data[1].ToString() ;
        }
        public override string GetData()
        {
            return Clientid.ToString() + MessageSeparators.dataSeparator + ClientCategory.ToString();
        }
    }

