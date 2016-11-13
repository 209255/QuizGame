using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public interface ITCPServiceServer:IServiceCommunication
    {
        void AcceptConnection();
        void AcceptDisconnection();
    }

