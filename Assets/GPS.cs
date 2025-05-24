using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.XR.ARFoundation;

public class GPS : MonoBehaviour
{
    public Text gpsOut;
    public Text distanceInfo;
    public bool isUpdating;
    public float distance;
    public bool stopUpdate = false;
    public List<double> totalLongitude;
    public List<double> totalLatitude;
    private byte times = 0;

    //replace with Start() since i only need 1 pair of coordinates when the app starts
    void Update()
    {
        if (!stopUpdate)
        {
            if (!isUpdating)
            {
                StartCoroutine(GetLocation());
                isUpdating = !isUpdating;
            }
        }
    }

    public double GetDistance(double longitude, double latitude, double otherLongitude, double otherLatitude)
    {
        var d1 = latitude * (Math.PI / 180.0);
        var num1 = longitude * (Math.PI / 180.0);
        var d2 = otherLatitude * (Math.PI / 180.0);
        var num2 = otherLongitude * (Math.PI / 180.0) - num1;
        var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

        return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
    }
    IEnumerator GetLocation()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield return new WaitForSeconds(10);

        // Start service before querying location
        Input.location.Start(0);

        // Wait until service initializes
        int maxWait = 10;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            gpsOut.text = "Timed out";
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            gpsOut.text = "Unable to determine device location";
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            if (times < 5)
            {
                totalLongitude.Add(Input.location.lastData.longitude);
                totalLatitude.Add(Input.location.lastData.latitude);
                times++;
            }
            else
            {
                GameObject.Find("LoadingParent").SetActive(false);
                stopUpdate = true;
                StopCoroutine(GetLocation());
                isUpdating = true;
                Input.location.Stop();
                
                gpsOut.text = string.Join(",", totalLatitude.Average(), totalLongitude.Average());

                //jasht n oborr (21.15476, 42.64239)
                //zyre te une (21.15491, 42.64221)
                distance = (float)GetDistance(totalLongitude.Average(), totalLatitude.Average(), 21.15491, 42.64221);
                distanceInfo.text = "Distance is: " + distance.ToString();

                //why is this causing 3d object to shift??

                var sessionOrigin = GameObject.Find("AR Session Origin");
                //var session = GameObject.Find("AR Session");
                var indicator = GameObject.Find("Indicator");

                Vector3 currentPosition = indicator.transform.position;
                Vector3 forwardOffset = indicator.transform.forward * distance;
                Vector3 finalPosition = currentPosition + forwardOffset;

                indicator.transform.position = finalPosition;
                sessionOrigin.transform.position = finalPosition;
                //session.transform.position = finalPosition;
            }
        }

        // Stop service if there is no need to query location updates continuously
        isUpdating = !isUpdating;
        Input.location.Stop();
    }
}