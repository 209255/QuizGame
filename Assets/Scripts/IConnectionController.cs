
    public interface IConnectionController
    {
        IServiceCommunication communication { get; }
        void OnTCPSelected();
        void OnUDPSelected();
        void OnBluetoothSelected();

    }

