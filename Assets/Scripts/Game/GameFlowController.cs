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
        communication.RegisterCallback(MessageSubject.ServerStartGame, OnStartGame);
        communication.RegisterCallback(MessageSubject.ServerPlayerJoin,OnPlayerJoin);
        communication.RegisterCallback(MessageSubject.ServerAssignToRoom, OnAssignToRoom);

    }
    
    void ReadyToStart()
    {

    }
    void SendScore()
    {

    }
    void SendCategory()
    {

    }
    void OnPlayerJoin(IMessage msg)
    {
        ServerPlayerJoinToYourRoom message = new ServerPlayerJoinToYourRoom(msg);
    }
    void OnAssignToRoom(IMessage msg)
    {
        ServerAssignToRoom message = new ServerAssignToRoom(msg);
    }
    void OnStartGame(IMessage msg)
    {
        ServerStartGame message = new ServerStartGame(msg);
        
    }
    void OnScoreReceive(IMessage msg)
    {
        ScoreMsg message = new ScoreMsg(msg);
    }
    void OnCategoryReceive(IMessage msg)
    {
        CategoryMsg message = new CategoryMsg(msg);
    }
    void OnCreateRoom(IMessage msg)
    {
        ServerOnCreateRoom message = new ServerOnCreateRoom(msg);
    }

    public GameFlowController(IClientServiceCommunication com)

    {
        this.communication = com;

    }
    }

