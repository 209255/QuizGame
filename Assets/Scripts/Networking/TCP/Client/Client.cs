using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

 class Client : IClient
{
    
    public string ip
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public int port
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public bool Connect(string ip, int port)
    {
        throw new NotImplementedException();
    }

    public bool Disconnect()
    {
        throw new NotImplementedException();
    }

    public string[] Read()
    {
        throw new NotImplementedException();
    }

    public void Send(IMessage msg)
    {
        throw new NotImplementedException();
    }
}

