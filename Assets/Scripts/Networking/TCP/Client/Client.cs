using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

 class Client : IClient
{
    private ITcpClient socket;
    private ICommunication communication;
    private IClientConnection connection;

    public string ip { get { return connection.ip; } }
    public int port { get { return connection.port; } }
    public bool isReady { get; private set; }
    public bool isHost { get; private set; }
    public int score { get; private set;}


    public Client()
    {
        socket = new TCPClientAdapter();
        communication = new ClientCommunication(socket);
        connection = new ClientConnection(socket);
    }
    public bool Connect(string ip, int port)
    {
        return connection.Connect(ip, port);
    }
    public bool Disconnect()
    {
        return connection.Disconnect();
    }
    public string[] Read()
    {
        return communication.Read();
    }
    public void Send(IMessage message)
    {
        communication.Send(message.ToString());
    }

 
}

