using Autofac;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour {
    private int score;
    private QuestionMenu questionMenu;
  

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
        questionMenu.LoadQuestions(jsonName);
        GameObject.Find("CategoryTab/Text").GetComponentInChildren<Text>().text = jsonName;
        OnClick();
    }

    public void OnClick()
    {
        if (questionMenu.CanClick)
        {
            if (!questionMenu.ShowNextQuestion())
            {
                IMenuManager menuResult = DependencyResolver.Container.Resolve<IMenuManager>();
                menuResult.ShowMenu(GameObject.Find("Result").GetComponent<Menu>());
                GameObject.Find("Score").GetComponent<Text>().text = score.ToString() + "/" + questionMenu.QuestionNum;
            }
        }
    }

    void OnDestroy()
    {
        if (questionMenu != null)
            questionMenu.CorrenctAnswer -= Answered;
    }
}
