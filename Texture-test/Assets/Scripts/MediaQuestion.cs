using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediaQuestion : MonoBehaviour
{
    public GameObject canvasQuestion;
    public TourManager tourManager;
    public QuizManager questionManager;
    // Start is called before the first frame update
    void Start()
    {
        canvasQuestion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canvasQuestion.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            HideQuestion();
        }
    }

    public void ShowQuestion(GameObject buttonObject)
    {
        Debug.Log(buttonObject.GetComponent<QuestionIndex>().questionIndex);
        questionManager.currentQuestion = buttonObject.GetComponent<QuestionIndex>().questionIndex;
        questionManager.generateQuestion();
        canvasQuestion.SetActive(true);
        tourManager.OpenMedia();
    }

    public void HideQuestion()
    {
        canvasQuestion.SetActive(false);
        tourManager.ReturnToSite();
    }
}
