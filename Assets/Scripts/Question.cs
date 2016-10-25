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
    public bool nextQuestion;
    public bool clickQuestion;
	public void QuestionBegin(string jsonName)
    {
        nextQuestion = true;
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
        if (nextQuestion)
        {
            var ansDestroy = GameObject.FindGameObjectsWithTag("Answer");
            if (ansDestroy != null)
            {
                foreach (var ans in ansDestroy)
                    DestroyImmediate(ans);
            }
            GameObject.Find("Question/Panel/QuestionContainer/Question/Text").GetComponentInChildren<Text>().text = questionData["data"][QuestionNum]["question"].ToString();

            for (var i = 0; i < questionData["data"][QuestionNum]["answer"].Count; i++)
            {
                var answer = Instantiate(ansPrefab);
                answer.GetComponentInChildren<Text>().text = questionData["data"][QuestionNum]["answer"][i].ToString();
                var answerC = GameObject.Find("AnswersContainer").GetComponent<Transform>();
                answer.transform.SetParent(answerC);

                string offset = i.ToString();
                if (i == 0)
                {
                    answer.name = "Correct";
                    answer.GetComponent<Button>().onClick.AddListener(() => Answer("0"));
                }
                else
                {
                    answer.name = "Wrong" + offset;
                    answer.GetComponent<Button>().onClick.AddListener(() => Answer(offset));
                }
                answer.transform.SetSiblingIndex(Random.Range(0, 3));
            }

            QuestionNum++;
            nextQuestion = false;
            clickQuestion = true;
        }
    }
    public void Answer(string questionNum)
    {
        if (clickQuestion)
        {
            if (questionNum == "0")
            {
                GameObject.Find("Correct").GetComponent<Button>().image.color = Color.green;
                GameObject.Find("Image ("+ QuestionNum+")").GetComponent<Image>().color= Color.green;
                Debug.Log("Answer correct");
            }
            else
            {
                GameObject.Find("Wrong" + questionNum).GetComponent<Button>().image.color = Color.red;
                GameObject.Find("Image ("+QuestionNum+")").GetComponent<Image>().color = Color.red;
                Debug.Log("Answer wrong");
            }
        }
        nextQuestion = true;
        clickQuestion = false;
    }
}
