using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private Vector3 acceleration;
    private Compass compass;
    private Quaternion gyro;
    public GameObject GameWorld;
    GeoDataHosei Hosei;
    GeoDataTamachi Tamachi;
    float Unitydis;
    float Geodis;
    //double Unitydis;
    //double Geodis;

    public GameObject BldHosei;
    public GameObject BldTamachi;
    Vector3 GeoHosei;
    Vector3 GeoTamachi;
    Vector3 UnityHosei;
    Vector3 UnityTamachi;
    float Converter;
    //double Converter;
    Vector3 GeoCam;


    // Use this for initialization
    void Start()
    {
        Input.compass.enabled = true;
        Input.gyro.enabled = true;

        Input.location.Start();

        GameWorld.transform.rotation = Quaternion.Euler(new Vector3(0, Input.compass.trueHeading, 0));

        Unitydis = Vector3.Distance(BldHosei.transform.position, BldTamachi.transform.position);

        UnityHosei = BldHosei.transform.position;
        UnityTamachi = BldTamachi.transform.position;
        GeoHosei = new Vector3(35.69548f, 0, 139.74059f);
        
        GeoTamachi = new Vector3(35.69561f, 0, 139.737f);
        
        Geodis = Vector3.Distance(GeoHosei, GeoTamachi);
        Converter = Unitydis/Geodis;

        GeoCam = new Vector3(35.69111f, 0f, 139.73563f);


        var Geovec2 = (GeoHosei - GeoCam).normalized;
        var Geovec = (GeoHosei - GeoTamachi).normalized;
        var Unityvec = (UnityHosei - UnityTamachi).normalized;
        var angle2 = Vector3.Angle(Geovec,Unityvec);
        var finalvec = Quaternion.Euler(0, -angle2, 0) * Geovec2;
        
        this.transform.position = BldHosei.transform.position + (finalvec*100);
        Vector3 pos = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(pos.x , 350f, pos.z);
    }

    // Update is called once per frame
    void Update()
    {
        this.acceleration = Input.acceleration;
        this.gyro = Input.gyro.attitude;

        //// 加速度センサを利用してCubeを移動
        //float speed = 5.0f;

        //var dir = Vector3.zero;
        //dir.x = Input.acceleration.x;
        //dir.y = Input.acceleration.y;

        //if (dir.sqrMagnitude > 1)
        //{
        //    dir.Normalize();
        //}

        //dir *= Time.deltaTime;

        //transform.Translate(dir * speed);

        //地磁気センサーから値を取得
        //transform.rotation = Quaternion.Euler(0, -Input.compass.trueHeading, 0);

        // ジャイロセンサの値を取得し、Unity内のカメラと同期
        this.transform.localRotation = Quaternion.Euler(90, 0, 0) * (new Quaternion(-gyro.x, -gyro.y, gyro.z, gyro.w));

        // Cubeの位置を任意の位置に変更
        //Vector3 pos = transform.position;
        //pos.x = 0.5f;
        //transform.position = pos;
        //Debug.Log(transform.position);

        //// OK
        //transform.position = new Vector3(
        //    -4,
        //    -1,
        //    5);
    }
    public void OnCompassClick()
    {
        GameWorld.transform.rotation = Quaternion.Euler(new Vector3(0, Input.compass.trueHeading, 0));
    }
}
