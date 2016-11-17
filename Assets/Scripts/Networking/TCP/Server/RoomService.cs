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
 
    public void AddPlayerToExistingRoom()
    {
        
    }
    public void OnNewClient(Client client)
    {
       
    }
    public void AddPlayertoNewRoom()
    {
        throw new NotImplementedException();
    }

    public void CloseRoom()
    {
        throw new NotImplementedException();
    }

    public void CreateNewRoom()
    {
        
    }

    public void LeftPlayerFromRoom()
    {
        throw new NotImplementedException();
    }
}

