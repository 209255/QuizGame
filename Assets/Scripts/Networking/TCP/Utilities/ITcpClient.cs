using System.Net.Sockets;

public interface ITcpClient
    {
    bool Connected { get; }
    void Connect(string ip, int port);
    NetworkStream GetStream();
    void Close();
}

