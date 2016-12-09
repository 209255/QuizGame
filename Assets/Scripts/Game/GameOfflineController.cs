using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class GameOfflineController:IGameFlowController
    {
    public IMenuManager menuManager;
    private Menu categoryMenu;
    private Menu ResultMenu;
    Question questionController;

    public GameOfflineController()
    {
        menuManager = DependencyResolver.Container.Resolve<IMenuManager>();
        ResultMenu = GameObject.FindGameObjectWithTag("Result").GetComponent<Menu>();
        questionController = GameObject.FindObjectOfType<Question>(); ;
        categoryMenu = GameObject.FindGameObjectWithTag("CategoryMenu").GetComponent<Menu>();
        ShowCategory();
    }

    public void OnCategorySelected(string category)
    {
        questionController.QuestionBegin(category);
    }

    public void OnFinishQuestions()
    {
        ShowResultMenu();
        questionController.ShowResult();
    }

    private void ShowCategory()
    {
        menuManager.ShowMenu(categoryMenu);

    }
    private void ShowResultMenu()
    {
        menuManager.ShowMenu(ResultMenu);
    }
    }

