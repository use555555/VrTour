using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
    public Renderer blocker;
    [Range(0, 5)]
    public int pauseBeforeFade;

    Color fadeColor;

    [Range(1, 10)]
    public float fadeTime = 1;
    float currentTime;
    float colorLerp;

    bool canStartFade = false;
    bool startFadeIn = false;
    bool startFadeOut = true;


    // Start is called before the first frame update
    void Start()
    {
        fadeColor = blocker.material.color;
        colorLerp = fadeColor.a;
        StartCoroutine(StartCameraFade());
    }

    // Update is called once per frame
    void Update()
    {
        if(canStartFade)
        {
            currentTime += Time.deltaTime;
            if(startFadeOut)
            {
                colorLerp = Mathf.Lerp(1, 0, currentTime / fadeTime);
                fadeColor.a = colorLerp;
                blocker.material.color = fadeColor;
            }
            else if(startFadeIn)
            {
                colorLerp = Mathf.Lerp(0, 1, currentTime / fadeTime);
                fadeColor.a = colorLerp;
                blocker.material.color = fadeColor;
            }
            
            if(currentTime >= fadeTime)
            {
                FadeComplete();
            }
        }

    }

    public void FadeComplete()
    {
        canStartFade = false;
        startFadeIn = false;
        startFadeOut = false;
    }

    public void FadeIn()
    {
        currentTime = 0;
        startFadeIn = true;
        StartCoroutine("StartCameraFade");
    }

    public void FadeOut()
    {
        currentTime = 0;
        startFadeOut = true;
        StartCoroutine("StartCameraFade");
    }

    IEnumerator StartCameraFade()
    {
        yield return new WaitForSeconds(pauseBeforeFade);

        canStartFade = true;

        yield return null;
    }
}
