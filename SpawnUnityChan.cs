using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnityChan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Input.compass.enabled = true;
        // GPS機能の利用開始
        Input.location.Start();
        this.transform.Rotate(new Vector3(0,-Input.compass.trueHeading,0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
