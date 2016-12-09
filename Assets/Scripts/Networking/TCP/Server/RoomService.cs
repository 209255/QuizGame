using System;
using System.Collections.Generic;

public class RoomService:IRoomService
    {
    private List<Room> rooms;
    ITCPServiceServer communication;
    

    private void RegisterAction()
    {
        communication.RegisterCallback(MessageSubject.ServerAssignToRoom, OnAskedForJoinGame);
        communication.RegisterCallback(MessageSubject.ClientSendCategory, OnCategoryReceived);
        communication.RegisterCallback(MessageSubject.ClientReadyToStart, OnClientReady);
        communication.RegisterCallback(MessageSubject.ClientSendScore, OnScoreReceived);
    }

    private void OnScoreReceived(IMessage msg)
    {
        ScoreMsg message = new ScoreMsg(msg);
        ushort id = message.Clientid;
        Room room = FindRoomWithPlayer(id);
        if (room != null)
        {
            room.GetIfContainsPlayerInRoom(id).score = message.ClientScore;
        }
        if (room.AllClientsAnswered())
            SendScore(room);
            

    }

    private void SendScore(Room room)
    {
        ScoreMsg message = new ScoreMsg(room.clients[0].PlayerId,room.clients[0].score);
        communication.SendTo(room.clients[1].PlayerId, message);

        message = new ScoreMsg(room.clients[1].PlayerId, room.clients[1].score);
        communication.SendTo(room.clients[0].PlayerId, message);

    }

    private Room FindRoomWithPlayer(ushort id)
    {
        foreach(Room rom in rooms)
        {
            if (rom.GetIfContainsPlayerInRoom(id)!=null)
                return rom;
        }
        return null;
    }
    private void OnClientReady(IMessage msg)
    {
        ReadyToStartMsg message = new ReadyToStartMsg(msg);
        ushort id = message.Clientid;
        Room room = FindRoomWithPlayer(id);
        if (room != null)
        {
            room.GetIfContainsPlayerInRoom(id).isReady = true;
        }
        if (room.AllClientsReady())
            SendStartGame(room);

    }

    private void SendStartGame(Room room)
    {
        ServerStartGame message = new ServerStartGame(0, room.Category);
        foreach (Player player in room.clients)
            communication.SendTo(player.PlayerId, message);
    }

    private void OnCategoryReceived(IMessage msg)
    {
        CategoryMsg message = new CategoryMsg(msg);
        ushort id = message.Clientid;
        Room room = FindRoomWithPlayer(id);
        if (room != null)
        {
            room.Category = message.ClientCategory;
        }

    }

    public RoomService()
    {
      
    }

    public RoomService(ITCPServiceServer communication)
    {
        rooms = new List<Room>();
        this.communication = communication; 

        
    }

    public void AddPlayerToExistingRoom(ushort playerId,Room room)
    {
        ServerPlayerJoinToYourRoom message = new ServerPlayerJoinToYourRoom(room.clients[0].PlayerId);
        communication.SendTo(room.clients[0].PlayerId, message);
        room.AddClient(playerId);
        ServerAssignToRoom msg = new ServerAssignToRoom(playerId);
        communication.SendTo(playerId, msg);
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
        ServerOnCreateRoom message = new ServerOnCreateRoom(client);
        rooms.Add(new Room());
        rooms[rooms.Count].AddClient(client);
        communication.SendTo(client, message);
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
            {
                communication.SendTo(players.PlayerId, msg);
                roomToDelete.RemoveClient(players.PlayerId);
            }
        }
    }

   
    public void LeftPlayerFromRoom(ushort playerLeftId)
    {
        PlayerLeftRoom msg = new PlayerLeftRoom();
        Room roomPlayer = null;
        Player leavingPlayer = null;
        foreach (var room in rooms)
        {
            leavingPlayer = room.GetIfContainsPlayerInRoom(playerLeftId);
            if (leavingPlayer != null)
                roomPlayer = room;
        }
          
        if (leavingPlayer != null && leavingPlayer.isHost == true)
        {
            foreach (var players in roomPlayer.clients)
            {
                communication.SendTo(players.PlayerId, msg);
                roomPlayer.RemoveClient(players.PlayerId);
            }
            CloseRoom(playerLeftId);
        }
        if (leavingPlayer != null && leavingPlayer.isHost == false)
        {
            roomPlayer.RemoveClient(playerLeftId);
            communication.SendTo(roomPlayer.clients[0].PlayerId, msg);
        }
        
    }
}

