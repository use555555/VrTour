using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion = 0;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public TextMeshProUGUI QuestionTxt;
    public TextMeshProUGUI ScoreTxt;

    public TextMeshProUGUI ScoreShow;
    public TextMeshProUGUI QuestionShow;

    int totalQuestions = 0;
    List<int> questionState;
    public int score;
    public void Start()
    {
        totalQuestions = QnA.Count;
        questionState = new List<int>(totalQuestions);
        GoPanel.SetActive(false);
        for (int i = 0; i < totalQuestions; i++)
        {
            questionState.Add(0);
        }
    }

    void Update()
    {
        ScoreShow.text = "Score: " + score + "/" + totalQuestions;
        int finishQuestion = 0;
        for (int i = 0; i < totalQuestions; i++)
        {
            if(questionState[i]!=0)
            {
                finishQuestion += 1;
            }
        }
        QuestionShow.text = "Question: " + finishQuestion + "/" + totalQuestions;
    }

    public void retry()
    {
        Quizpanel.SetActive(true);
        GoPanel.SetActive(false);
        if (questionState[currentQuestion] == 1)
        {
            score -= 1;
        }
        questionState[currentQuestion] = 0;
        generateQuestion();
    }
    void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        if (questionState[currentQuestion] == 1)
        {
            ScoreTxt.text = "Correct";
        }
        else
        {
            ScoreTxt.text = "Wrong";
        }
        
    }

    public void correct()
    {
        score += 1;
        questionState[currentQuestion] = 1;
        GameOver();
    }

    public void wrong()
    {
        questionState[currentQuestion] = 2;
        GameOver();
    }
    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            Debug.Log(options[i].transform.GetChild(0));
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    public void generateQuestion()
    {
        if (questionState[currentQuestion] != 0)
        {
            GameOver();
        }
        else
        {
            Quizpanel.SetActive(true);
            GoPanel.SetActive(false);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
    }
}
