using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourManager : MonoBehaviour
{
    //list of sites
    public GameObject[] objSites;
    private GameObject site;

    public Video VideoManager;
    public MediaQuestion QuestionManager;
    public MediaImage ImageManager;
    public FadeScript fadeScript;

    
    // Start is called before the first frame update
    void Start()
    {
        LoadSite(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadSite(int siteNumber)
    {
        //show site
        site = Instantiate(objSites[siteNumber]);
        site.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        //enable the camera
    }

    public void ReturnToSite()
    {
        site.SetActive(true);
    }
    public void OpenMedia()
    {
        site.SetActive(false);
    }

    public void Warp(GameObject buttonObject)
    {
        StartCoroutine(WaitForFade(buttonObject));
    }

    IEnumerator WaitForFade(GameObject buttonObject)
    {
        fadeScript.FadeIn();
        yield return new WaitForSeconds(fadeScript.fadeTime);
        Destroy(site);
        LoadSite(buttonObject.GetComponent<Warp>().goToSite);
        fadeScript.FadeOut();
        yield return null;
    }
}