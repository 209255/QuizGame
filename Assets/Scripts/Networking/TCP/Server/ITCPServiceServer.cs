using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    interface ITCPServiceServer:ICommunnication
    {
        void AcceptConnection();
        void AcceptDisconnection();
    }

