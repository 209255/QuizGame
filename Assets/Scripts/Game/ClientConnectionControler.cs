using System;



class ClientConnectionControler : IClientConnectionController
{
    private ConnectionButtonsModel connectionButtonsModel;
    private string ip = "192.168.1.104";
    private int port = 8000;
    public IGameFlowController gameFlowController { get; private set; }
    
    public ClientConnectionControler(ConnectionButtonsModel connectionButtonsModel)
    {
        this.connectionButtonsModel = connectionButtonsModel;
        connectionButtonsModel.OfflineButton.onClick.AddListener(OnOfflineSelected);
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

    public void OnOfflineSelected()
    {
        gameFlowController = new GameOfflineController();
    }

    public void OnTCPSelected()
    {
        client = new TCPServiceClient();
        client.Connect(ip,port);
        gameFlowController = new GameFlowController(client);
    }
    public void OnUDPSelected()
    {
        throw new NotImplementedException();
    }
}

