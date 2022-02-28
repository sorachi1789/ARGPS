using UnityEngine;

public static class CameraExtensions
{

    /// <summary>
    /// ���C���[��ݒ肷��
    /// </summary>
    /// <param name="needSetChildrens">�q�ɂ����C���[�ݒ���s����</param>
    public static void SetLayer(this GameObject gameObject, int layerNo, bool needSetChildrens = true)
    {
        if (gameObject == null)
        {
            return;
        }
        gameObject.layer = layerNo;

        //�q�ɐݒ肷��K�v���Ȃ��ꍇ�͂����ŏI��
        if (!needSetChildrens)
        {
            return;
        }

        //�q�̃��C���[�ɂ��ݒ肷��
        foreach (Transform childTransform in gameObject.transform)
        {
            SetLayer(childTransform.gameObject, layerNo, needSetChildrens);
        }
    }

    /// <summary>
    /// �}�e���A���ݒ�
    /// </summary>
    /// <param name="needSetChildrens">�q�ɂ��}�e���A���ݒ���s����</param>
    public static void SetMaterial(this GameObject gameObject, Material setMaterial, bool needSetChildrens = true)
    {
        if (gameObject == null)
        {
            return;
        }

        //�����_���[������΂��̃}�e���A����ύX
        if (gameObject.GetComponent<Renderer>())
        {
            gameObject.GetComponent<Renderer>().material = setMaterial;
        }

        //�q�ɐݒ肷��K�v���Ȃ��ꍇ�͂����ŏI��
        if (!needSetChildrens)
        {
            return;
        }

        //�q�̃}�e���A���ɂ��ݒ肷��
        foreach (Transform childTransform in gameObject.transform)
        {
            SetMaterial(childTransform.gameObject, setMaterial, needSetChildrens);
        }

    }


}