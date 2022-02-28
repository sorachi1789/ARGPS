using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLookAtTarget : MonoBehaviour
{

    [SerializeField] private Transform target;

    void Update()
    {
        this.gameObject.transform.LookAt(target);
    }
}