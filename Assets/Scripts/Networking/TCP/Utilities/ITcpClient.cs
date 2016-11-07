using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

public interface ITcpClient
    {
    bool Connected { get; }
    void Connect(string ip, int port);
    NetworkStream GetStream();
    void Close();
}

