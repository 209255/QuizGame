using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;


    public class Server:IServer
    {
    private IConnectionHandler connectionHandler;
    private IServerCommunication communication;
    private IServerSetUp setUp;
    public List<IClientHandler> clients;
    public NewMessage NewMessage { get { return communication.onNewMessage; } set { communication.onNewMessage = value; } }
    public Action<ushort> NewConnection { get { return connectionHandler.NewConnection; } set { connectionHandler.NewConnection = value; } }


    private ITcpListener socket;

    public Server(int port = 8000)
    {
        socket = new TcpListenerAdapter(IPAddress.Any, port);
        clients = new List<IClientHandler>();
        connectionHandler = new ConnectionHandler(socket, clients);
        communication = new ServerCommunication(clients);
        setUp = new ServerSetUp(socket);
    }

    public void Start()
    {
        setUp.Start();
        connectionHandler.Start();
    }

    public void Stop()
    {
        setUp.Stop();
        socket.Stop();
    }

    public void SendTo(ushort id, IMessage message)
    {
        communication.SendTo(id, message);
    }
    public void Broadcast(IMessage message)
    {
        communication.SendToAll(message);
    }
    public void SendToOthers(ushort id, IMessage message)
    {
        foreach (var client in clients)
            if (client.GetId() != id)
                SendTo(client.GetId(), message);
    }
    public void Read()
    {
        communication.Read();
    }
    public void RemoveClient(ushort id)
    {
        connectionHandler.RemoveClient(id);
    }

}

