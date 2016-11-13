using System;
using System.Net.Sockets;
using System.Text;


    class ClientCommunication:ICommunication
    {
        ITcpClient socket;
        private readonly char[] endOfMessageSeparator = { MessageSeparators.endOfTCPMessageSeparator };
        public ClientCommunication(ITcpClient socket)
        {
            this.socket = socket;
        }

        public string[] Read()
        {
            NetworkStream stream = socket.GetStream();
            byte[] bytes = new byte[1024];
            StringBuilder message = new StringBuilder();
            while (stream.DataAvailable)
            {
                int num = stream.Read(bytes, 0, 1024);
                message.Append(Encoding.UTF8.GetString(bytes, 0, num));
            }
            string[] messages = message.ToString().Split(endOfMessageSeparator, StringSplitOptions.RemoveEmptyEntries);
            return messages;
        }

        public void Send(string message)
        {
            NetworkStream stream = socket.GetStream();
            byte[] bytes = Encoding.UTF8.GetBytes(message.ToCharArray());
            stream.Write(bytes, 0, message.Length);
        }
    }


