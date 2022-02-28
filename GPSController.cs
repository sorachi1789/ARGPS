using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSController : MonoBehaviour
{
    //35.70044852628062, 139.54495394715164
    public double latitude = 35.70044852628062;  
    public double longitude = 139.54495394715164; 
    const double lat2km = 111319.491;

    public Vector3 ConvertGPS2ARCoordinate(LocationInfo location)
    {
        double dz = (latitude - location.latitude) * lat2km;   // -z‚ª“ì•ûŒü
        double dx = -(longitude - location.longitude) * lat2km; // +x‚ª“Œ•ûŒü
        return new Vector3((float)dx, 0, (float)dz);
    }

    void Start()
    {
        Input.location.Start();
        

        Invoke("UpdateGPS", 1.0f);
    }

    public void UpdateGPS()
    {
        if (Input.location.isEnabledByUser)
        {
            if (Input.location.status == LocationServiceStatus.Running)
            {
                LocationInfo location = Input.location.lastData;

                transform.position = ConvertGPS2ARCoordinate(location);
            }
        }
    }
}