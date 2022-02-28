using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealWorld : MonoBehaviour
{
    public GameObject ARCamera;
    // Start is called before the first frame update
    void Start()
    {
        Input.compass.enabled = true;
        Input.location.Start();
        //transform.rotation = Quaternion.Euler(0, -Input.compass.headingAccuracy, 0);
        transform.rotation = Quaternion.Euler(0, -ARCamera.transform.rotation.y, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
