using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class GameFlowController:IGameFlowController
    {
    private IClientServiceCommunication communication;
    public IMenuManager menuManager;
    private Menu categoryMenu;
    private Menu readyToStart;
    private Menu ResultMenu;
    private QuestionMenu questionMenu;
    Question questionController;
    private Button readyStart;
    private string category;
    private int score;
    private bool oponentFinished = false;
    private void RegisterAction()
    {
        communication.RegisterCallback(MessageSubject.ServerAssignToRoom,OnAssignToRoom);
        communication.RegisterCallback(MessageSubject.Score, OnScoreReceive);
        communication.RegisterCallback(MessageSubject.ServerStartGame, OnStartGame);
        communication.RegisterCallback(MessageSubject.ServerPlayerJoin,OnPlayerJoin);
        communication.RegisterCallback(MessageSubject.ServerAssignToRoom, OnAssignToRoom);
        communication.RegisterCallback(MessageSubject.QuestionFinished, OnFinishedQuestion);
        communication.RegisterCallback(MessageSubject.ServerCreateRoom, OnCreateRoom);
   
        if (communication.isConnected)
            AskToJoinGame();
        else
            communication.OnIdFromServer += AskToJoinGame;
    }

    private void AskToJoinGame()
    {
        PlayerAskedToJoinGame msg = new PlayerAskedToJoinGame(communication.id);
        communication.Send(msg);
    }

    void ReadyToStart()
    {
        ReadyToStartMsg msg = new ReadyToStartMsg(communication.id);
        communication.Send(msg);
    }
    void SendScore()
    {
        ScoreMsg msg = new ScoreMsg(communication.id, questionController.score);
        communication.Send(msg);
    }
    void OnPlayerJoin(IMessage msg)
    {
        ServerPlayerJoinToYourRoom message = new ServerPlayerJoinToYourRoom(msg);
        ShowReadyToStartMenu();
    }
    void OnAssignToRoom(IMessage msg)
    {
        ServerAssignToRoom message = new ServerAssignToRoom(msg);
    }
    void OnStartGame(IMessage msg)
    {
        ServerStartGame message = new ServerStartGame(msg);
        category = message.Category;
        menuManager.ShowMenu(questionMenu);
        questionController.QuestionBegin(category);
     
    }
    void OnScoreReceive(IMessage msg)
    {
        ScoreMsg message = new ScoreMsg(msg);
        questionController.ShowResult(message.ClientScore);
        


    }
    void OnCreateRoom(IMessage msg)
    {
        ServerOnCreateRoom message = new ServerOnCreateRoom(msg);
        ShowCategory();
    }

    public void OnCategorySelected(string category)
    {
        CategoryMsg message = new CategoryMsg(communication.id, category);
        communication.Send(message);
        this.category = category; 
        ShowReadyToStartMenu();
    }
    public void OnFinishedQuestion(IMessage msg)
    {
        FinishedQuestion message = new FinishedQuestion(msg);
        oponentFinished = true;
    }
    private void ShowReadyToStartMenu()
    {
        menuManager.ShowMenu(readyToStart);
    }

    private void ShowCategory()
    {
        menuManager.ShowMenu(categoryMenu);

    }
    private void ShowResult()
    {
        menuManager.ShowMenu(ResultMenu);

    }
    public void OnFinishQuestions()
    {
        ScoreMsg msg = new ScoreMsg(communication.id,score);
        communication.Send(msg);
        
            
    }

    public GameFlowController(IClientServiceCommunication com)
    {
        
        this.communication = com;
        RegisterAction();
        menuManager = DependencyResolver.Container.Resolve<IMenuManager>();
        questionController = GameObject.FindObjectOfType<Question>(); ;
        categoryMenu = GameObject.FindGameObjectWithTag("CategoryMenu").GetComponent<Menu>();
        readyToStart = GameObject.FindGameObjectWithTag("ReadyToStart").GetComponent<Menu>();
        readyStart = GameObject.FindGameObjectWithTag("PressStart").GetComponent<Button>();
        ResultMenu = GameObject.FindGameObjectWithTag("Result").GetComponent<Menu>();
        questionMenu = GameObject.FindObjectOfType<QuestionMenu>(); 
        readyStart.onClick.AddListener(ReadyToStart);
    }
}

