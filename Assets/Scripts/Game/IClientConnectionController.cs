
  public interface IClientConnectionController
    {
    IClientServiceCommunication client { get; }
    void OnTCPSelected();
    void OnUDPSelected();
    void OnBluetoothSelected();
    void OnOfflineSelected();
}

