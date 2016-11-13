using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public interface IRoomService
    {
    void CreateNewRoom();
    void CloseRoom();
    void AddPlayerToExistingRoom();

    void LeftPlayerFromRoom();
    void OnNewClient(Client client);
    }

