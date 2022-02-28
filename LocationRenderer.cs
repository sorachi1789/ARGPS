using UnityEngine;
using UnityEngine.UI;

public class LocationRenderer : MonoBehaviour
{
    public LocationUpdater updater;
    public Text text;

    void Update()
    {
        text.text = updater.Status.ToString()
                  + "\n" + "lat:" + updater.Location.latitude.ToString()
                  + "\n" + "lng:" + updater.Location.longitude.ToString();
    }
}