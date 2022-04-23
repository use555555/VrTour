using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public GameObject VideoMenu;
    public VideoClip[] Videolist;

    public TourManager tourManager;
    public VideoPlayer videoToPlay;
    // Start is called before the first frame update
    void Start()
    {
        VideoMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (VideoMenu.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            HideVideo();
        }
    }

    public void ShowVideo(GameObject buttonObject)
    {
        int currentVideo = buttonObject.GetComponent<VideoIndex>().videoIndex;
        VideoMenu.SetActive(true);  
        tourManager.OpenMedia();
        videoToPlay.clip = Videolist[currentVideo];
        videoToPlay.Play();
    }

    public void HideVideo()
    {
        VideoMenu.SetActive(false);  
        tourManager.ReturnToSite();
        videoToPlay.Stop(); 
    }
}
