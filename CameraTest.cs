using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//これをつけ加え忘れるとエラーが出ます

public class CameraTest : MonoBehaviour
{
    public RawImage rawImage;
    WebCamTexture webCamTexture;

    // Start is called before the first frame update
    void Start()
    {
        webCamTexture = new WebCamTexture();
        rawImage.texture = webCamTexture;
        webCamTexture.Play();
    }
}