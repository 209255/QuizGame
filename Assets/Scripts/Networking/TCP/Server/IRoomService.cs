    public interface IRoomService
    {
        void CloseRoom(ushort client);
        void AddPlayerToExistingRoom(ushort playerId, Room room);
        void LeftPlayerFromRoom(ushort playerLeftId);
        void OnAskedForJoinGame(IMessage message);
    }

