using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Room
    {
        public List<Player> clients { get; private set; }
        public string Category { get; private set; }
        public bool isFull { get; private set; }
        public Room()
        {
            clients = new List<Player>();
        }

        public void AddClient(ushort playerID)
        {
            clients.Add(new Player(playerID));
        }
        public void RemoveClient(ushort playerID)
        {
            
            clients.Remove(clients.Single(cl =>cl.PlayerId == playerID ));
        }
        public Player GetIfContainsPlayerInRoom(ushort playerId)
        {
                // zrobic ss do inzynierki
            return clients.FirstOrDefault(client => client.PlayerId == playerId);
        }
    }

