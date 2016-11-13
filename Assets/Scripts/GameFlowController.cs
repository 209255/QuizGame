using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


   class GameFlowController
    {
    private IClientServiceCommunication communication;
    private void RegisterAction()
    {
        communication.RegisterCallback(MessageSubject.ServerAssignToRoom,OnAssignToRoom);
        communication.RegisterCallback(MessageSubject.Score, OnScoreReceive);
    }
    
    void ReadyToStart()
    {

    }
    void SendScore()
    {

    }
    void OnPlayerJoin()
    {

    }
    void OnAssignToRoom(IMessage msg)
    {

    }
    void OnStartGame(IMessage msg)
    {

    }
    void OnScoreReceive(IMessage msg)
    {
        ScoreMsg message = new ScoreMsg(msg);
    }
    void OnCreateRoom(IMessage msg)
    {

    }

    public GameFlowController(IClientServiceCommunication com)

    {
        this.communication = com;

    }
    }

