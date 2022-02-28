
using UnityEngine;
using UnityEngine.UI;

    public class CameraControll2 : MonoBehaviour
{
    bool C = false;
    public Material Occlusion;
    public Material Def;
    Renderer Mate;

    //ŒÄ‚Ño‚µ‚ÉÀs‚³‚ê‚éŠÖ”
    void Start()
    {
        Mate = this.gameObject.GetComponent<Renderer>();   
    }

    public void GetCam()
    {

        if (!C)
        {
            Mate.material = Occlusion;
            C = true;
        }
        else
        {
            Mate.material = Def;
            C = false;
        }
    }
}