using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    interface ITCPServiceClient:ICommunnication
    {
        void Connect();
        void Disconnect();
    }

