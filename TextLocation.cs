using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLocation : MonoBehaviour
{
    [SerializeField]
    private Text m_trueHeading;

    // Start is called before the first frame update
    void Start()
    {
        Input.location.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.location.isEnabledByUser)
        {
            if (Input.location.status == LocationServiceStatus.Running)
            {
                LocationInfo location = Input.location.lastData;
            }
            m_trueHeading.text = ("Location: " + Input.location.lastData.latitude + " "
                               + "\n" + Input.location.lastData.longitude + " "
                               + "\n" + Input.location.lastData.altitude + " "
                               + "\n" + Input.location.lastData.horizontalAccuracy + " "
                               + "\n" + Input.location.lastData.timestamp);
        }
        else
        {
            m_trueHeading.text = ("False");
        }

    }
}