using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraRotation : MonoBehaviour //UnityïWèÄÉNÉâÉXÇåpè≥
{
    public GameObject UnityCam;
    Slider ThisSlider;
    ProgramV2 programV2;

    // Start is called before the first frame update
    void Start()
    {
        ThisSlider = GetComponent<Slider>();
        programV2 = UnityCam.GetComponent<ProgramV2>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Method()
    {
        programV2.CameraRot = ThisSlider.value;
    }
}

