using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChange1 : MonoBehaviour
{
    public GameObject RawCam;
    
    public void Onclick()
    {
        RawCam.SetActive(false);
    }
}
