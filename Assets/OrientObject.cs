using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class OrientObject : MonoBehaviour
{
    //[SerializeField] private GameObject initialPositionObject;
    //private Vector3 offset;
    //public Text compassNumbers;
    //public Text compassDirectionText;

    //private void Start()
    //{
    //    //offset = transform.position - initialPositionObject.transform.position;
    //    //ARSession.stateChanged += OnARSessionStateChanged;
    //    Input.location.Start();
    //    Input.compass.enabled = true;
    //}

    //private void Update()
    //{
    //    //float heading = Input.compass.magneticHeading;
    //    Quaternion compass = Quaternion.Euler(0, -Input.compass.magneticHeading, 0);

    //    //if (heading < 0f)
    //    //{
    //    //    heading += 360f; // Convert negative values to a positive range
    //    //}

    //    // Determine the compass direction based on the heading
    //    //string compassDirection = GetCompassDirection(compass);
    //    compassNumbers.text = compass.ToString();
    //    compassDirectionText.text = "Compass Direction: " + Input.compass.trueHeading;
    //}

    //private string GetCompassDirection(float heading)
    //{
    //    // You can define your own logic for determining the direction based on the heading
    //    if (heading >= 22.5f && heading < 67.5f)
    //    {
    //        return "NE"; // North-East
    //    }
    //    else if (heading >= 67.5f && heading < 112.5f)
    //    {
    //        return "E"; // East
    //    }
    //    else if (heading >= 112.5f && heading < 157.5f)
    //    {
    //        return "SE"; // South-East
    //    }
    //    else if (heading >= 157.5f && heading < 202.5f)
    //    {
    //        return "S"; // South
    //    }
    //    else if (heading >= 202.5f && heading < 247.5f)
    //    {
    //        return "SW"; // South-West
    //    }
    //    else if (heading >= 247.5f && heading < 292.5f)
    //    {
    //        return "W"; // West
    //    }
    //    else if (heading >= 292.5f && heading < 337.5f)
    //    {
    //        return "NW"; // North-West
    //    }
    //    else
    //    {
    //        return "N"; // North
    //    }
    //}

    //private void OnARSessionStateChanged(ARSessionStateChangedEventArgs args)
    //{
    //    if (args.state == ARSessionState.SessionTracking)
    //    {
    //        // AR session is tracking; place the object
    //        transform.position = initialPositionObject.transform.position + offset;
    //    }
    //}
    public TextMeshPro headingText;

    private bool startTracking = false;

    void Start()
    {
        Input.compass.enabled = true;
        Input.location.Start();
        StartCoroutine(InitializeCompass());
    }

    void Update()
    {
        if (startTracking)
        {
            transform.rotation = Quaternion.Euler(0, Input.compass.trueHeading, 0);
            headingText.text = ((int)Input.compass.trueHeading).ToString() + "° " + DegreesToCardinalDetailed(Input.compass.trueHeading);
        }
    }

    IEnumerator InitializeCompass()
    {
        yield return new WaitForSeconds(1f);
        startTracking |= Input.compass.enabled;
    }

    private static string DegreesToCardinalDetailed(double degrees)
    {
        string[] caridnals = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "N" };
        return caridnals[(int)Math.Round(((double)degrees * 10 % 3600) / 225)];
    }
}