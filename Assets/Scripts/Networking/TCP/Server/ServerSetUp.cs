using System;
using System.Net.Sockets;

public class ServerSetUp : IServerSetUp
{
    private ITcpListener socket;
    public ServerSetUp(ITcpListener socket)
    {
        this.socket = socket;

    }

    public bool Start()
    {
        if(!socket.IsBound)
        {
            socket.Start();
            return true;
        }
        return false;
    }

    public bool Stop()
    {
        if (socket.IsBound)
        {
            socket.Stop();
            return true;
        }
        return false;
    }
}

