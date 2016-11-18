using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class RoomService:IRoomService
    {
    private List<Room> rooms;
    ITCPServiceServer communication;
    private void RegisterAction()
    {
        communication.RegisterCallback(MessageSubject.ServerAssignToRoom, OnAskedForJoinGame);
    }
    public RoomService()

    {
        rooms = new List<Room>();
   
    }
 
    public void AddPlayerToExistingRoom(ushort playerId,Room room)
    {
        ServerPlayerJoin msg = new ServerPlayerJoin(playerId);
        communication.SendTo(room.clients[0].PlayerId, msg);
        room.AddClient(playerId);
        ServerPlayerJoinToYourRoom message = new ServerPlayerJoinToYourRoom(room.clients[0].PlayerId);
        communication.SendTo(playerId, message);
       

    }
    public void OnAskedForJoinGame(IMessage message)
    {
        PlayerAskedToJoinGame msg = new PlayerAskedToJoinGame(message);
        Room freeRoom = null;
        foreach (var room in rooms)
        {
            if (room.isFull)
                continue;
            freeRoom = room;
            break;
        }
        if (freeRoom == null)
            AddPlayertoNewRoom(msg.Clientid);
        else
            AddPlayerToExistingRoom(msg.Clientid,freeRoom);
    }

    public void AddPlayertoNewRoom(ushort client)
    {
        rooms.Add(new Room());
        rooms[rooms.Count].AddClient(client);
    }

    public void CloseRoom(ushort playerId)
    {
        ClosedRoom msg = new ClosedRoom();
        Player player;
        Room roomToDelete = null;
        foreach (var room in rooms)
        {
            player = room.GetIfContainsPlayerInRoom(playerId);
            if (player != null)
                roomToDelete = room;
         }      
        if(roomToDelete.isFull)
        {
            foreach (Player players in roomToDelete.clients)
                communication.SendTo(players.PlayerId, msg);

        }
    }

   
    public void LeftPlayerFromRoom()
    {
        
    }
}

