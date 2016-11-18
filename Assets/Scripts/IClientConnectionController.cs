using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


  public interface IClientConnectionController
    {
    IClientServiceCommunication client { get; }
    void OnTCPSelected();
    void OnUDPSelected();
    void OnBluetoothSelected();
    void OnOfflineSelected();


}

