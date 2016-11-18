using System.Net.Sockets;
using System.Text;



    public class ClientHandler : IClientHandler
    {
        public static ushort idEnumerator = 1; 
        private TcpClient client;
        public ushort id;

        public ushort GetId()
        {
            return id;
        }
        public ClientHandler(TcpClient client)
        {
            this.client = client;
            id = idEnumerator;
            idEnumerator++;
        }

        public bool DataAvailable
        {
            get { return client.GetStream().DataAvailable; }
        }

        public string Read()
        {
            NetworkStream stream = client.GetStream();
            byte[] bytes = new byte[1024];
            StringBuilder message = new StringBuilder();
            while (stream.DataAvailable)
            {
                int num = stream.Read(bytes, 0, 1024);
                message.Append(Encoding.UTF8.GetString(bytes, 0, num));
            }
            return message.ToString();
        }

        public void Send(string message)
        {
            NetworkStream stream = client.GetStream();
            byte[] bytes = Encoding.UTF8.GetBytes(message.ToCharArray());
            stream.Write(bytes, 0, message.Length);
        }

        public bool isConnected()
        {
            return client.Connected;
        }
    }
