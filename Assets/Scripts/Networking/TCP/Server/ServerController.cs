using UnityEngine;

class ServerController: MonoBehaviour
{
    ITCPServiceServer server;
    private IRoomService roomService;
    void Awake()
    {
        server = new TCPServiceServer(new Server());
        server.Start();
        roomService = new RoomService(server);


    }
    void OnDestory()
    {
        server.Stop();
    }
}

