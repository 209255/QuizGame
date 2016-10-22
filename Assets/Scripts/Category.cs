using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
public class Category : MonoBehaviour {


    public GameObject katPrefab;
    
	// Use this for initialization
	void Start () {
        string filePath = Application.streamingAssetsPath;
        DirectoryInfo dir = new DirectoryInfo(filePath);
        FileInfo[] files = dir.GetFiles("*.json");
        foreach(var file in files)
        {
            GameObject kat = Instantiate(katPrefab) as GameObject;
            kat.name = Path.GetFileNameWithoutExtension(file.Name).ToString();
            kat.transform.SetParent(GameObject.Find("Category/Panel/CategoryContainer").GetComponent<Transform>());
            kat.GetComponentInChildren<Text>().text = kat.name;
        }
	}
    public void OnClick(string category)
    {
        Debug.Log(category);
    }
}
