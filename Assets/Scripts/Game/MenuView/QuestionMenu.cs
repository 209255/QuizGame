using LitJson;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class QuestionMenu : Menu
{
    public int QuestionNum { get; private set; }
    public event Action<bool> CorrenctAnswer;
    public bool CanClick { get; private set; }
    public GameObject ansPrefab;
    private string filePath;
    private string jsonString;
    private bool nextQuestion;
    private JsonData questionData;
    private bool clickQuestion;
    

    public void LoadQuestions(string fileName)
    {
        DestoryStats();
        QuestionNum = 0;
        filePath = Path.Combine(Application.streamingAssetsPath, fileName + ".json");
        StartCoroutine("Json");
        questionData = JsonMapper.ToObject(jsonString);
        CanClick = true;
        nextQuestion = true;
      
    }
    public bool ShowNextQuestion()
    {

        if (QuestionNum == questionData["data"].Count)
            return false;
        if (nextQuestion)
        {
            DestroyAnswers();
            LoadAnswers();
            QuestionNum++;
            clickQuestion = true;
            CanClick = false;
            nextQuestion = false;
            StartCoroutine("Timer");

        }
        return true;
    }
    public void Answer(string answerNum)
    {
        if (clickQuestion)
        {
            if (answerNum == "0")
            {
                CorrenctAnswer(true);
                GameObject.Find("Correct").GetComponent<Button>().image.color = Color.green;
                GameObject.Find("Image (" + QuestionNum + ")").GetComponent<Image>().color = Color.green;
            }
            else
            {
                CorrenctAnswer(false);
                var g = GameObject.Find("Wrong" + answerNum).GetComponent<Button>().image;
                g.color = Color.red;
                GameObject.Find("Image (" + QuestionNum + ")").GetComponent<Image>().color = Color.red;
            }
        }
        nextQuestion = true;
        CanClick = true;
        clickQuestion = false;

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
            jsonString = File.ReadAllText(filePath);
    }
    private void DestroyAnswers()
    {
        if (nextQuestion)
        {
            var ansDestroy = GameObject.FindGameObjectsWithTag("Answer");
            if (ansDestroy != null)
            {
                foreach (var ans in ansDestroy)
                    DestroyImmediate(ans);
            }
        }
    }
    private void DestoryStats()
    {
        for(int i = 1;i<10;i++)
        {
            GameObject.Find("Image (" + i + ")").GetComponent<Image>().color = Color.black;
        }
    }
    private void LoadAnswers()
    {
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
            answer.transform.SetSiblingIndex(UnityEngine.Random.Range(0, 3));
        }
    }

    IEnumerator Timer()
    {
      
        Image time = GameObject.Find("Timer").GetComponent<Image>();
        time.fillAmount = 1;
        float timeToWait = 3f;
        float incrementToRemote = 0.05f;
        float delta = time.fillAmount / timeToWait * incrementToRemote;

        while (timeToWait > 0)
        {
            yield return new WaitForSeconds(incrementToRemote);
            if (!nextQuestion)
            {
                time.fillAmount -= delta;
                timeToWait -= incrementToRemote;
            }
            else
                timeToWait = 0;
        }
        if (time.fillAmount <= 0.1f)
        {
            for (int i = 1; i < 4; i++)
                GameObject.Find("Wrong" + i).GetComponent<Button>().image.color = Color.red;

            GameObject.Find("Correct").GetComponent<Button>().image.color = Color.green;
            GameObject.Find("Image (" + QuestionNum + ")").GetComponent<Image>().color = Color.red;
            clickQuestion = false;
            nextQuestion = true; 
            CanClick = true;
        }
    }
}
