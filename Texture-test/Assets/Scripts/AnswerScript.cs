using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    private QuizManager quizManager;

    public void Start()
    {
        quizManager = GameObject.Find("SystemManager").GetComponent<QuizManager>();
    }

    public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager.wrong();
        }
    }
}
