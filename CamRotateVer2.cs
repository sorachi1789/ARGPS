using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CamRotateVer2 : MonoBehaviour
{
    public GameObject GameStage;
    public GameObject BldHosei;
    public GameObject BldTamachi;

    private Vector3 acceleration;
    private Compass compass;
    private Quaternion gyro;

    Vector3 GeoHosei;
    Vector3 GeoTamachi;
    Vector3 GeoCam;

    Vector3 UnityHosei;
    Vector3 UnityTamachi;
    bool a = false;

    private void Start()
    {

        Input.location.Start();
        Input.compass.enabled = true;
        Input.gyro.enabled = true;

        

        UnityHosei = BldHosei.transform.position; //Unity�̂ڂ킻�ȁ[��
        UnityTamachi = BldTamachi.transform.position;�@//Unity�̓c���L�����p�X

        
    }

    private void Update()
    {
        if (!a)
        {

            Invoke("InputGeoCam", 2.5f);
            a =true;
        }
        this.acceleration = Input.acceleration;
        this.gyro = Input.gyro.attitude;
        this.transform.localRotation = Quaternion.Euler(90, 0, 0) * (new Quaternion(-gyro.x, -gyro.y, gyro.z, gyro.w));
    }

    private void InputGeoCam()
    {
        GeoHosei = new Vector3(139.74059f, 0, 35.69548f) * 100; //�n�}��̂ڂ킻�ȁ[��
        GeoTamachi = new Vector3(139.737f, 0, 35.69561f) * 100; //�n�}��̓c���L�����p�X

        //GeoCam = new Vector3(139.73563f, 0f, 35.69111f) * 10000; //�s���J�w
        //GeoCam = new Vector3(139.72883f, 0f, 35.69293f) * 10000;�@//�h�q��
        //GeoCam = new Vector3(139.74249f, 0f, 35.68576f) * 100; //���{�J����������
        //GeoCam = new Vector3((float)Input.location.lastData.longitude , 0, (float)Input.location.lastData.latitude) * 10000; //�c���L�����p�X
        GeoCam = new Vector3(0f, 0f,0f) * 100; //�c���L�����p�X


        var Geovec = (GeoTamachi - GeoHosei).normalized;�@�@�@�@�@//�n�}��̂ڂ킻�Ɠc���̃x�N�g���@�@�@
        var Unityvec = (UnityTamachi - UnityHosei).normalized;�@�@//Unity�̂ڂ킻�Ɠc���̃x�N�g��
        var ConvertAngle = Vector3.Angle(Geovec, Unityvec);�@�@�@ //Unit�ƒn�}��̃x�N�g���̊p�x

        var Geovec2 = GeoCam - GeoHosei;�@�@//�n�}��̃J����(�X�}�z�̈ʒu)�Ƃڂ킻�̃x�N�g��
        var finalvec = Quaternion.Euler(0, -ConvertAngle, 0) * Geovec2;�@//�p�x����

        this.transform.position = BldHosei.transform.position + (finalvec * 10f);//�J�����ʒu�ړ�
        Vector3 pos = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(pos.x, 3.5f, pos.z);

        Debug.Log(ConvertAngle);
        Debug.Log("finalvec" + finalvec);
        Debug.Log("Geovec2" + Geovec2);
        //GameStage.transform.RotateAround(this.transform.position,Vector3.up,-Input.compass.trueHeading);
    }
}