using System;
using System.Collections;
using System.Collections.Generic;
using GeoCoordinateUtility;
using UnityEngine.UI;
using UnityEngine;


public class ProgramV2 : MonoBehaviour
{
    public GameObject Position;
    public GameObject Button1;
    Text PosText;

    public GameObject Slider;
    Slider CamZoom;

    double firstlon;
    double firstlat;
    double altitude;

    private Vector3 acceleration;
    private Compass compass;
    private Quaternion gyro;

    bool push = false;
    bool left = false;
    bool right = false;
    bool foward = false;
    bool behind = false;
    bool up = false;
    bool down = false;

    float posx = 0;
    float posy = 0;
    float posz = 0;

    public float CameraRot;


    void Start()
    {
        PosText = Position.GetComponent<Text>();
        CamZoom = Slider.GetComponent<Slider>();
        if (Input.location.isEnabledByUser)
        {
            Input.compass.enabled = true;
            Input.location.Start();
            Input.gyro.enabled = true;
            this.transform.position = new Vector3(0f, 0.02f, 0f);

            //firstlon = 139.74059;
            //firstlat = 35.69548;
        }
        else
        {
            PosText.text = "No GPS";
        }
    }

    private void Update()
    {
        //firstlog = (double)Input.location.lastData.longitude;
        //firstlat = (double)Input.location.lastData.latitude;
        //PosText.text = "Log:" + firstlog + "\n" + "Lat:" + firstlat;
        this.acceleration = Input.acceleration;
        this.gyro = Input.gyro.attitude;
        this.transform.localRotation = Quaternion.Euler(90, 0, 0) * (new Quaternion(-gyro.x, -gyro.y, gyro.z, gyro.w)) * Quaternion.Euler(0,CameraRot, 0);
        PosText.text = "Log:" + firstlon + "\n" + "Lat:" + firstlat + "\n" + "Alt:" + altitude + "\n" + "Field of View" + CamZoom.value + "\n" + "CamRotate" + CameraRot;
        if (left)
        {
            //posx = posx - 0.01f;
            transform.Translate(-0.01f, 0, 0);
        }
        if (right)
        {
            //posx = posx + 0.01f;
            transform.Translate(0.01f, 0, 0);
        }
        if (up)
        {
            //posy = posy + 0.01f;
            transform.Translate(0, 0.01f, 0);
        }
        if (down)
        {
            //posy = posy - 0.01f;
            transform.Translate(0, -0.01f, 0);
        }
        if (behind)
        {
            //posz = posz - 0.01f;
            transform.Translate(0, 0, -0.01f);
        }
        if (foward)
        {
            //posz = posz + 0.01f;
            transform.Translate(0, 0, 0.01f);
        }
    }

    public void ButtonClickdown()
    {
        firstlat = Input.location.lastData.latitude; //+ 0.00414;
        firstlon = Input.location.lastData.longitude; //+ 0.19571;
        altitude = Input.location.lastData.altitude;
        PosText.text = "Lat:" + firstlat + "\n" + "Log:" + firstlon;
        //35.700634333123745, 139.54488294944196
        //35.69548f 139.74059f bowaso
        //firstlat = 35.69548;
        //firstlon = 139.74059;
        var coordinate = GeoCoordinateConverter.LatLon2Coordinate(
            lat0_deg: firstlat,
            lon0_deg: firstlon,
            latOrigin_deg: 36.00000000,
            lonOrigin_deg: 139 + 50d / 60d);
        this.transform.position = new Vector3((float)coordinate.Y / 100,
                                                  (float)altitude / 100,
                                                  (float)coordinate.X / 100);
        PosText.text = "Log:" + firstlon + "\n" + "Lat:" + firstlat + "\n" + "Alt:" + altitude + "\n" + "Field of View" + CamZoom.value;
        //Button1.SetActive(false);
    }

    public void LeftButtonD()
    {
        push = true;
        left = true;
    }
    public void LeftButtonU()
    {
        push = false;
        left = false;
    }
    public void RightButtonD()
    {
        push = true;
        right = true;
    }
    public void RightButtonU()
    {
        push = false;
        right = false;
    }
    public void BehindButtonD()
    {
        push = true;
        behind = true;
    }
    public void BehindButtonU()
    {
        push = false;
        behind = false;
    }
    public void ForwordButtonD()
    {
        push = true;
        foward = true;
    }
    public void ForwordButtonU()
    {
        push = false;
        foward = false;
    }
    public void UpButtonD()
    {
        push = true;
        up = true;
    }
    public void UpButtonU()
    {
        push = false;
        up = false;
    }
    public void DownButtonD()
    {
        push = true;
        down = true;
    }
    public void DownButtonU()
    {
        push = false;
        down = false;
    }
    void onDisable()
    {
        // アプリ終了時にGPSを停止する（電池節約）
        Input.location.Stop();
    }
}