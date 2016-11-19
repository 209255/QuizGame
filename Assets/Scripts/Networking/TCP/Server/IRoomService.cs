using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public interface IRoomService
    {

    void CloseRoom(ushort client);
    void AddPlayerToExistingRoom(ushort playerId, Room room);
    void LeftPlayerFromRoom(ushort playerLeftId);

    void OnAskedForJoinGame(IMessage message);
    }

