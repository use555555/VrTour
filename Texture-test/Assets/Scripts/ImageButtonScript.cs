using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageButtonScript : MonoBehaviour
{
    public MediaImage imageManager;
    // Start is called before the first frame update
    void Start()
    {
        imageManager = GameObject.Find("SystemManager").GetComponent<MediaImage>();
    }

    public void ShowImage()
    {
        imageManager.ShowImage(this.gameObject);
    }
}
