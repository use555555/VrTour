using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionButtonScript : MonoBehaviour
{
    public MediaQuestion questionManager;
    // Start is called before the first frame update
    void Start()
    {
        questionManager = GameObject.Find("SystemManager").GetComponent<MediaQuestion>();
    }

    public void ShowQuestion()
    {
        questionManager.ShowQuestion(this.gameObject);
    }
}
