using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Room
{
    public List<Player> clients { get; private set; }
    public string Category { get; set; }
    public bool isFull { get; private set; }
    public Room()
    {
        clients = new List<Player>();
    }
    public bool AllClientsAnswered()
    {
        foreach (Player player in clients)
        {
            if (player.score == -1)
                return false;
        }
        return true;

    }
    public bool AllClientsReady()
    {
        foreach (Player player in clients)
        {
            if (player.isReady == false)
                return false;
        }
        return true;

    }
    public void AddClient(ushort playerID)
    {
        clients.Add(new Player(playerID));
        if (clients.Count == 1)
            clients[0].isHost = true;
        if (clients.Count == 2)
            isFull = true;
    }
    public void RemoveClient(ushort playerID)
    {
        clients.Remove(clients.Single(cl => cl.PlayerId == playerID));
        if (clients.Count == 1)
            isFull = false;
    }
    public Player GetIfContainsPlayerInRoom(ushort playerId)
    {
        // zrobic ss do inzynierki
        return clients.FirstOrDefault(client => client.PlayerId == playerId);
    }


}

