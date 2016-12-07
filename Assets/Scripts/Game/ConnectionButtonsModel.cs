﻿using UnityEngine;
using UnityEngine.UI;

class ConnectionButtonsModel:MonoBehaviour
    {
        public Button TCPButton;
        public Button UDPButton;
        public Button BluetoothButton;
        public Button OfflineButton;
        public IClientConnectionController controler { get; private set; }

    void Start()
    {
        controler = new ClientConnectionControler(this);
        
    }
   
    }
