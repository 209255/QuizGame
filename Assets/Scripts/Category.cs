﻿using UnityEngine;
using UnityEngine.UI;
using Autofac;
using System.IO;
public class Category : MonoBehaviour {


    private GameObject katPrefab;
    private MenuManager menu;
    private Question question;

	void Start () {

        RectTransform rect = gameObject.GetComponent<RectTransform>();
        string filePath = Application.streamingAssetsPath;
        DirectoryInfo dir = new DirectoryInfo(filePath);
        FileInfo[] files = dir.GetFiles("*.json");
        foreach(var file in files)
        {
            GameObject kat = Instantiate(katPrefab) as GameObject;
            kat.name = Path.GetFileNameWithoutExtension(file.Name).ToString();
            kat.transform.SetParent(GameObject.Find("Category/Panel/Scroll/CategoryContainer").GetComponent<Transform>());
            kat.GetComponentInChildren<Text>().text = kat.name;
            kat.GetComponent<Button>().onClick.AddListener(() => OnClick(kat.name));
            kat.GetComponent<Button>().onClick.AddListener(() => DependencyResolver.Container.Resolve<IMenuManager>().ShowMenu(GameObject.Find("Canvas/Question").GetComponent<Menu>()));
        }
        rect.sizeDelta = new Vector2(rect.sizeDelta.x,(rect.sizeDelta.y/6)*files.Length);
	}
    public void OnClick(string category)
    {
        question.QuestionBegin(category);
    }
}
