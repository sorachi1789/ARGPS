
using UnityEngine;
using UnityEngine.UI;

    public class CameraControll : MonoBehaviour
{
    bool C = false;
    public Material Occlusion;
    public Material Def;
    bool needSet = true;

    //�Ăяo�����Ɏ��s�����֐�
    void Start()
    {
        //�T�u�J�������A�N�e�B�u�ɂ���
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