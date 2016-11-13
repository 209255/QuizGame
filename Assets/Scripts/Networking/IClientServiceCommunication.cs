using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



  public interface IClientServiceCommunication:IServiceCommunication
    {
     
    bool Connect(string ip,int port);
    bool Disconnect();

}

