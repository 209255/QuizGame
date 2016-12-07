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
    Question questionController;
    public GameOfflineController()
    {

        menuManager = DependencyResolver.Container.Resolve<IMenuManager>();
        questionController = GameObject.FindObjectOfType<Question>(); ;
        categoryMenu = GameObject.FindGameObjectWithTag("CategoryMenu").GetComponent<Menu>();
    }

    public void OnCategorySelected(string category)
    {
        questionController.QuestionBegin(category);
    }

    void ShowCategory()
    {
        menuManager.ShowMenu(categoryMenu);

    }
    }

