using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoButtonScript : MonoBehaviour
{
    public Video videoManager;
    // Start is called before the first frame update
    void Start()
    {
        videoManager = GameObject.Find("SystemManager").GetComponent<Video>();
    }

    public void ShowVideo()
    {
        videoManager.ShowVideo(this.gameObject);
    }
}
