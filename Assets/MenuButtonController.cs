using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Autofac;

public class MenuButtonController : MonoBehaviour {

    public Menu menuToLoad;
    public IMenuManager menuManager;

	void Start () {
        GetComponent<Button>().onClick.AddListener(LoadMenu);
        menuManager = DependencyResolver.Container.Resolve<IMenuManager>();
	}

    private void LoadMenu()
    {
        menuManager.ShowMenu(menuToLoad);
    }
}
