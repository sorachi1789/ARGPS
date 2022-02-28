using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChange : MonoBehaviour
{
    public GameObject RawCam;
    void Start()
    {
        RawCam.SetActive(false);
    }
    public void Onclick() 
    {
        RawCam.SetActive(true);
    }
}
