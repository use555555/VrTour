using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpButtonScript : MonoBehaviour
{
    public TourManager tourManager;
    // Start is called before the first frame update
    void Start()
    {
        tourManager = GameObject.Find("TourManager").GetComponent<TourManager>();
    }

    public void Warp()
    {
        tourManager.Warp(this.gameObject);
    }
}
