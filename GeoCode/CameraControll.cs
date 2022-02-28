
using UnityEngine;
using UnityEngine.UI;

    public class CameraControll : MonoBehaviour
{
    bool C = false;
    public Material Occlusion;
    public Material Def;
    bool needSet = true;

    //呼び出し時に実行される関数
    void Start()
    {
        //サブカメラを非アクティブにする
        //ARCamera.SetActive(false);
    }

    public void GetCam()
    {

        if (!C)
        {
            CameraExtensions.SetMaterial(
                gameObject: this.gameObject,
                setMaterial: Occlusion,
                needSetChildrens: needSet);
            C = true;
        }
        else
        {
            CameraExtensions.SetMaterial(
                gameObject: this.gameObject,
                setMaterial: Def,
                needSetChildrens: needSet);
            C = false;
        }
    }
}