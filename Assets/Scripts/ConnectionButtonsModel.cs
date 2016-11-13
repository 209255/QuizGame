using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class ConnectionButtonsModel:MonoBehaviour
    {
        public Button TCPButton;
        public Button UDPButton;
        public Button BluetoothButton;
        private IClientConnectionController controler;

    void Start()
    {
        controler = new ClientConnectionControler(this);
    }
   
    }

