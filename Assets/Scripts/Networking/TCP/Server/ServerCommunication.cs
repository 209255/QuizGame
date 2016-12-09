using System;
using System.Collections.Generic;

public delegate void NewMessage(ushort id, IMessage msg);

class ServerCommunication : IServerCommunication
{
    private List<IClientHandler> clients;
    private readonly char[] endOfMessageSeparator = { MessageSeparators.endOfTCPMessageSeparator };
    public NewMessage onNewMessage { get; set; }
    public ServerCommunication(List<IClientHandler> clients)
    {
        this.clients = clients;
    }
    public void Read()
    {
        for (int i = 0; i < clients.Count; ++i)
        {
            var registeredClient = clients[i];
            if (registeredClient.DataAvailable)
            {
                string rawMessages = registeredClient.Read();
                string[] messages = rawMessages.Split(endOfMessageSeparator, StringSplitOptions.RemoveEmptyEntries);
                foreach (var message in messages)
                {
                    var messageObject = new Message(message);
                    onNewMessage(registeredClient.GetId(), messageObject);
                }
            }
        }
    }
    public void SendTo(ushort id, IMessage msg)
    {
        var handler = clients.Find(client => client.GetId() == id);
        if (handler != null)
        {
            handler.Send(msg.ToString());

            return;
        }
        throw new ClientNotExistException();
    }

    public void SendToAll(IMessage msg)
    {
        if (clients.Count == 0)
            throw new ClientNotExistException();
        foreach (var handler in clients)
        {
            handler.Send(msg.ToString());
        }
    }
}

    public class ClientNotExistException : Exception
    {

        public override string Message
        {
            get
            {
                return "Client with specified Id does not exist";
            }
        }
    }