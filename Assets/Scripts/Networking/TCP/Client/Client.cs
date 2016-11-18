using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

 public class Client : IClient
{
    private ITcpClient socket;
    private IClientCommunication communication;
    private IClientConnection connection;

    public string ip { get { return connection.ip; } }
    public int port { get { return connection.port; } }
    

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

