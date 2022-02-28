using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraZoom : MonoBehaviour //UnityïWèÄÉNÉâÉXÇåpè≥
{
    public GameObject UnityCam;
    Camera ZoomCam;
    Slider ThisSlider;

    // Start is called before the first frame update
    void Start()
    {
        ZoomCam = UnityCam.GetComponent<Camera>();
        ThisSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Method()
    {
        ZoomCam.fieldOfView = ThisSlider.value;
    }
}
