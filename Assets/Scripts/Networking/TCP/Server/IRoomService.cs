using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public interface IRoomService
    {
    void CreateNewRoom(Client client);
    void CloseRoom(Client client);
    void AddPlayerToExistingRoom(Client client);
    void LeftPlayerFromRoom(Client client);
    void OnNewClient(Client client);
    }

