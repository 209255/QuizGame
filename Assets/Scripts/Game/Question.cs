using Autofac;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour {
    public int score { get; private set; }
    private QuestionMenu questionMenu;
    private IClientConnectionController clientController;

    void Start()
    {
        questionMenu = FindObjectOfType<QuestionMenu>();
        questionMenu.CorrenctAnswer += Answered;
        clientController = GameObject.FindObjectOfType<ConnectionButtonsModel>().controler;
       

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
               
                clientController.gameFlowController.OnFinishQuestions();
            }
        }
    }
    public void ShowResult(int oponentScore = 0)
    {
        IMenuManager menuResult = DependencyResolver.Container.Resolve<IMenuManager>();
        menuResult.ShowMenu(GameObject.Find("Result").GetComponent<Menu>());
        GameObject.Find("Score").GetComponent<Text>().text = score.ToString() + "/" + questionMenu.QuestionNum;
        if (oponentScore != 0)
        {
            if (score > oponentScore)
            {
                GameObject.Find("WinOrLoose").GetComponent<Text>().text = "You Win!" + "\n Yours Opponent score was: " + oponentScore.ToString(); ;
            }
            else
                GameObject.Find("WinOrLoose").GetComponent<Text>().text = "You Loose!" + "\n Yours Opponent score was: " + oponentScore.ToString(); ;
        }
    }
    void OnDestroy()
    {
        if (questionMenu != null)
            questionMenu.CorrenctAnswer -= Answered;
    }
}
