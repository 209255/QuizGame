using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public interface ICommunication
    {
    string[] Read();
    void Send(string message);
}

