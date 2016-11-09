using System;
using System.Net.Sockets;


    public interface ITcpListener
    {
    bool IsBound { get; }
    IAsyncResult BeginAcceptSocket(AsyncCallback callback, object state);
    IAsyncResult BeginAcceptTcpClient(AsyncCallback callback, object state);
    TcpClient EndAcceptTcpClient(IAsyncResult asyncResult);
    void Start();
    void Stop();
}

