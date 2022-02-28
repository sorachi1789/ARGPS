using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPosision : MonoBehaviour
{
    [SerializeField]
    private Text TextPosi;
    public GameObject Box;
    public GameObject Session;
    public GameObject Real;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 BoxPosision = Session.transform.position - Box.transform.position;
        TextPosi.text = ("Box "+ "\n" + 
                         "P.x" + BoxPosision.x + "\n" +
                         "P.y" + BoxPosision.y + "\n" +
                         "R.z" + BoxPosision.z + "\n" +
                         "R.x" + Session.transform.rotation.x + "\n" +
                         "R.y" + Session.transform.rotation.y + "\n" +
                         "R.z" + Session.transform.rotation.z + "\n" +
                         "Real.x" + Real.transform.rotation.x + "\n" +
                         "Real.y" + Real.transform.rotation.y + "\n" +
                         "Real.z" + Real.transform.rotation.z );
    }
}
