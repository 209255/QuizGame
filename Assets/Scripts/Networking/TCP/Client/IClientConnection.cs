


    public interface IClientConnection
    {
        string ip { get; }
        int port { get; }
        bool Connect(string ip, int port);
        bool Disconnect();
    }

