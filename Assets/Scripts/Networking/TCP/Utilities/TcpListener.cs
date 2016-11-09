using System;
using System.Net;
using System.Net.Sockets;


namespace Assets.Scripts.Networking.TCP.Utilities
{
    public class TcpListener:ITcpListener
    {
        TcpListener client;

        public bool IsBound
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public TcpListener(IPAddress ip, int port)
        {
            client = new TcpListener(ip, port);
        }
        //public bool IsBound { get { return client..IsBound; } }
        public void Stop()
        {
            client.Stop();
        }
        public void Start()
        {
            client.Start();
        }
        public IAsyncResult BeginAcceptSocket(AsyncCallback callback, object state)
        {
            return client.BeginAcceptSocket(callback, state);
        }
        public IAsyncResult BeginAcceptTcpClient(AsyncCallback callback, object state)
        {
            return client.BeginAcceptTcpClient(callback, state);
        }

        public TcpClient EndAcceptTcpClient(IAsyncResult asyncResult)
        {
            return client.EndAcceptTcpClient(asyncResult);
        }
    }
}
