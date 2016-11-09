using System;
using System.Net;


    public class ClientConnection : IClientConnection
    {
        public string ip
        {
            get;
            private set;
        }

        public int port
        {
            get;
            private set;            
        }
        ITcpClient socket;
    public ClientConnection(ITcpClient socket)
    {
        this.socket = socket;
    }
    public bool Connect(string ip, int port)
        {
            if (!socket.Connected)
            {
                ValidateIP(ip);
                socket.Connect(ip, port);
                this.ip = ip;
                this.port = port;
                return true;
            }
            throw new ClientAlreadyConnectedException();
        }

        public bool Disconnect()
        {
            if (socket.Connected)
            {
                socket.Close();
                return true;
            }
            throw new ClientIsNotConnetedException();

        }
        private void ValidateIP(string ip)
        {
            IPAddress adr = null;
            if(!IPAddress.TryParse(ip,out adr))
                throw new InvalidIpAddressException();
        }
    }
    


public class InvalidIpAddressException : Exception
{
    public InvalidIpAddressException() : base("Ip address is invalid") { }
}

public class ClientIsNotConnetedException : Exception
{
    public ClientIsNotConnetedException() : base("Client is not connected to any server") { }
}

public class ClientAlreadyConnectedException : Exception
{
    public ClientAlreadyConnectedException() :
        base("Client is allready connected to server")
    {
    }
}