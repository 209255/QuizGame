using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ConnectionHandler : IConnectionHandler
{
    public Action<ushort> NewConnection
    {
        get;
        set;
    }
    private List<IClientHandler> clients;
    private Queue<ClientHandler> newClients = new Queue<ClientHandler>();
    private ITcpListener socket;

    public ConnectionHandler(ITcpListener socket,List<IClientHandler> clients)
    {
        this.clients = clients;
        this.socket = socket;
    }
    public void RemoveClient(ushort id)
    {
        var toRemove = clients.Find(client => (client.GetId() == id));
        if (toRemove != null)
        {
            clients.Remove(toRemove);
            return;
        }
        throw new ClientNotExistException();
    }

    public void Start()
    {
        socket.BeginAcceptSocket(new AsyncCallback(AcceptConnection), socket);
    }
    private void AcceptConnection(IAsyncResult result)
    {
        ClientHandler client = new ClientHandler(socket.EndAcceptTcpClient(result));
        NewClient(client);
    }
    private void NewClient(ClientHandler handler)
    {
        lock (newClients)
            newClients.Enqueue(handler);
        RegisterConnection();
        socket.BeginAcceptTcpClient(new AsyncCallback(AcceptConnection), socket);
    }
    private void RegisterConnection()
    {
        if (newClients.Count > 0)
        {
            var handler = newClients.Dequeue();
            clients.Add(handler);
            NewConnection(handler.id);
            //  Log.Print(LogTag.TCPServer, "New Client: " + handler.id);
        }
    }
}

