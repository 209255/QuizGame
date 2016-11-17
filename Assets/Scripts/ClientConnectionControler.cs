using System;



class ClientConnectionControler : IClientConnectionController
{
    private ConnectionButtonsModel connectionButtonsModel;
    private string ip;
    private int port;
    public ClientConnectionControler(ConnectionButtonsModel connectionButtonsModel)
    {
        this.connectionButtonsModel = connectionButtonsModel;
        connectionButtonsModel.UDPButton.onClick.AddListener(OnUDPSelected);
        connectionButtonsModel.TCPButton.onClick.AddListener(OnTCPSelected);
        connectionButtonsModel.BluetoothButton.onClick.AddListener(OnBluetoothSelected);
    }
    public IClientServiceCommunication client
    {
        get;private set;
    }
    public void OnBluetoothSelected()
    {
        
    }
     public void OnTCPSelected()
    {
        client = new TCPServiceClient();
        client.Connect(ip,port);
    }
    public void OnUDPSelected()
    {
        throw new NotImplementedException();
    }
}

