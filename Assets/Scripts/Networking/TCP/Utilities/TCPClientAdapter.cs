using  System.Net;
using System;
using System.Net.Sockets;
using System.Net.NetworkInformation;

class TCPClientAdapter : ITcpClient
{
    TcpClient client;
   
    public TCPClientAdapter()
    {
        
        IPAddress ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
        int port = FindFirstFreePort();
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
        client = new TcpClient(localEndPoint);
    }
    public int FindFirstFreePort()
    {
        IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
        TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
        int port = 100;

        while (true)
        {
            foreach (var connection in tcpConnInfoArray)
                if (connection.LocalEndPoint.Port != port)
                    return port;
            if (port <= IPEndPoint.MaxPort)
                ++port;
            else
                throw new NotImplementedException("Wszystkie porty są zajęte");
        }
    }
    public bool Connected { get { return client.Connected; } }

    public void Connect(string ip, int port)
    {
        client.Connect(ip, port);
    }
    public void Close()
    {
        client.GetStream().Close();
        client.Client.Close();
        client.Close();
    }
    public NetworkStream GetStream()
    {
        return client.GetStream();
    }
}

