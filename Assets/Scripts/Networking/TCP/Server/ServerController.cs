using UnityEngine;

class ServerController: MonoBehaviour
{
    ITCPServiceServer server;
    void Awake()
    {
        server = new TCPServiceServer(new Server());
        server.Start();
    }
    void OnDestory()
    {
        server.Stop();
    }
}

