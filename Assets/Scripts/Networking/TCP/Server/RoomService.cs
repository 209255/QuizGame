using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class RoomService:IRoomService
    {
    private List<Room> rooms;
    public RoomService()
    {
        rooms = new List<Room>();
    }
 
    public void AddPlayerToExistingRoom(Client client)
    {
        
    }
    public void OnNewClient(Client client)
    {
       
    }
    public void AddPlayertoNewRoom(Client client)
    {
        CreateNewRoom();
        rooms[1].AddClient(client);
    }

    public void CloseRoom(Client client)
    {
       
    }

    public void CreateNewRoom()
    {
        rooms.Insert(1, new Room());
    }

    public void LeftPlayerFromRoom(Client client)
    {
        foreach (var room in rooms)
            ;
    }
}

