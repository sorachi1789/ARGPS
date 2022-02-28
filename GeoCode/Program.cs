using System;
using System.Collections;
using System.Collections.Generic;
using GeoCoordinateUtility;
using UnityEngine.UI;
using UnityEngine;


namespace ConvertGeoCoordinate
{
    public class Program : MonoBehaviour
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
        bool AutoPos = false;


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
            this.transform.localRotation = Quaternion.Euler(90, 0, 0) * (new Quaternion(-gyro.x, -gyro.y, gyro.z, gyro.w));
            
        }

        public void ButtonClickdown()
        {
            //firstlat = Input.location.lastData.latitude; //+ 0.00414;
            //firstlon = Input.location.lastData.longitude; //+ 0.19571;
            altitude = Input.location.lastData.altitude;
            PosText.text = "Lat:" + firstlat + "\n" + "Log:" + firstlon;
            //35.700634333123745, 139.54488294944196
            //35.69548f 139.74059f bowaso
            firstlat = 35.69548;
            firstlon = 139.74059;
            var coordinate = GeoCoordinateConverter.LatLon2Coordinate(
                lat0_deg: firstlat,
                lon0_deg: firstlon,
                latOrigin_deg: 36.00000000,
                lonOrigin_deg: 139 + 50d / 60d);
            this.transform.position = new Vector3((float)coordinate.Y / 100, (float)altitude/100, (float)coordinate.X / 100);
            PosText.text = "Log:" + firstlon + "\n" + "Lat:" + firstlat + "\n" + "Alt:" + altitude + "\n" + "Field of View" + CamZoom.value;
            Button1.SetActive(false);
            AutoPos = true;
        }
        void onDisable()
        {
            // アプリ終了時にGPSを停止する（電池節約）
            Input.location.Stop();
        }
    }
}