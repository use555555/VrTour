using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediaImage : MonoBehaviour
{
    public Sprite[] ImageList;
    public GameObject canvasImage;
    public TourManager tourManager;
    float divider;
    // Start is called before the first frame update
    void Start()
    {
        canvasImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canvasImage.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            HideImage();
        }
    }

    public void ShowImage(GameObject buttonObject)
    {
        int currentImage = buttonObject.GetComponent<ImageIndex>().imageIndex;
        RectTransform objectRectTransform = canvasImage.transform.Find("UIbg").gameObject.transform.Find("Image").gameObject.GetComponent<RectTransform>();
        if (ImageList[currentImage].rect.width > ImageList[currentImage].rect.height)
        {
            divider = ImageList[currentImage].rect.width;
        }
        else
        {
            divider = ImageList[currentImage].rect.height;
        }
        objectRectTransform.sizeDelta = new Vector2((ImageList[currentImage].rect.width/ divider), (ImageList[currentImage].rect.height/ divider));
        canvasImage.transform.transform.Find("UIbg").Find("Image").gameObject.GetComponent<Image>().sprite = ImageList[currentImage];
        canvasImage.SetActive(true);
        tourManager.OpenMedia();
        Debug.Log("Pass");
    }

    public void HideImage()
    {
        canvasImage.SetActive(false);
        tourManager.ReturnToSite();
    }
}
