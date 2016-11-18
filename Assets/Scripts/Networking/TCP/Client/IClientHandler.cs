


    public interface IClientHandler
    {
        bool DataAvailable { get; }
        ushort GetId();
        bool isConnected();
        string Read();
        void Send(string message);
    }

