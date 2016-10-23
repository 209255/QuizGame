using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;
using UnityEngine.UI;
public class Question : MonoBehaviour {

    public string filePath;
    public string jsonString;
    public JsonData questionData;
    public int QuestionNum;
    public GameObject ansPrefab;
	public void QuestionBegin(string jsonName)
    {
        filePath = Path.Combine(Application.streamingAssetsPath, jsonName+".json");
        StartCoroutine("Json");
        questionData = JsonMapper.ToObject (jsonString);
        OnClick();

    }

    IEnumerator Json()
    {
        if (filePath.Contains("://"))
        {
            WWW www = new WWW(filePath);
            yield return www;
            jsonString = www.text;
        }
        else
        {
            jsonString = File.ReadAllText(filePath);
        }
    }

    public void OnClick()
    {
        var ansDestroy = GameObject.FindGameObjectsWithTag("Answer");
        if(ansDestroy != null)
        {
            foreach (var ans in ansDestroy)
                DestroyImmediate(ans);
        }
        GameObject.Find("Question/Panel/QuestionContainer/Question/Text").GetComponentInChildren<Text>().text = questionData["data"][QuestionNum]["question"].ToString();

        for(var i = 0; i <questionData["data"][QuestionNum]["answer"].Count; i++)
        {
            var answer = Instantiate(ansPrefab);
            answer.GetComponentInChildren<Text>().text = questionData["data"][QuestionNum]["answer"][i].ToString();
            var answerC = GameObject.Find("AnswersContainer").GetComponent<Transform>();
            answer.transform.SetParent(answerC);

            if(i==0)
             answer.GetComponent<Button>().onClick.AddListener(() => Answer(1));
            
            else
             answer.GetComponent<Button>().onClick.AddListener(() => Answer(0));
            answer.transform.SetSiblingIndex(Random.Range(0, 3));
        }
        
        QuestionNum++;

    }
    public void Answer(int x)
    {
        if (x == 1)
            Debug.Log("Answer correct");
        else
            Debug.Log("Answer wrong");
    }
}
