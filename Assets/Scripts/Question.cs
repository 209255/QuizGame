using Autofac;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour {

    public bool clickQuestion;
    public int score;
    private QuestionMenu questionMenu;
    private int questionsCount;

    void Start()
    {
        questionMenu = FindObjectOfType<QuestionMenu>();
        questionMenu.CorrenctAnswer += Answered;
    }

    private void Answered(bool isCorrect)
    {
        if (isCorrect)
            ++score;
    }

    public void QuestionBegin(string jsonName)
    {
        score = 0;
        questionsCount = questionMenu.LoadQuestions(jsonName);
        GameObject.Find("CategoryTab/Text").GetComponentInChildren<Text>().text = jsonName;
        OnClick();
    }

    public void OnClick()
    {
        
        if (!questionMenu.ShowNextQuestion())
        {
            IMenuManager menuResult = DependencyResolver.Container.Resolve<IMenuManager>();
            menuResult.ShowMenu(GameObject.Find("Result").GetComponent<Menu>());

            GameObject.Find("Score").GetComponent<Text>().text = score.ToString()+ "/" + questionsCount;
        }

    }

    void OnDestroy()
    {
        if (questionMenu != null)
            questionMenu.CorrenctAnswer -= Answered;
    }
}
