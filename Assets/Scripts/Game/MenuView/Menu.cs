using UnityEngine;
using Autofac;
using UnityEngine.UI;
using System;

public class Menu : MonoBehaviour {

    public bool isMainMenu = false;
	private Animator _animator;
	private CanvasGroup _canvasGroup;
    private Button[] myButtons;

	public bool IsOpen{

		get { return _animator.GetBool ("IsOpen");}
		set { _animator.SetBool ("IsOpen", value);}

	}

	public void Awake(){

		_animator = GetComponent<Animator> ();
		_canvasGroup = GetComponent<CanvasGroup> ();

		var rect = GetComponent<RectTransform> ();
		rect.offsetMax = rect.offsetMin = new Vector2 (0, 0);
        DisableButtons();
        RegisterMainMenu();

        myButtons = GetComponentsInChildren<Button>();
       

	}

    public void EnableButtons()
    {
        if (myButtons == null)
            return;
        foreach (Button but in myButtons)
            but.enabled = true;
    }
    public void DisableButtons()
    {
        if (myButtons == null)
            return;
        foreach (Button but in myButtons)
            but.enabled = false;
    }

    private void RegisterMainMenu()
    {
        if (isMainMenu) 
            DependencyResolver.Container.Resolve<IMenuManager>().RegisterMainMenu(this);
    }

    public void Update(){

		if (!_animator.GetCurrentAnimatorStateInfo (0).IsName ("Open")) {
			_canvasGroup.blocksRaycasts = _canvasGroup.interactable = false;
		} else {
			_canvasGroup.blocksRaycasts = _canvasGroup.interactable = true;

		}

	}
}