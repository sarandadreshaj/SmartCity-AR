using UnityEngine;
using UnityEngine.UI;

public class DistanceCalculation : MonoBehaviour
{
    public Transform targetObject;
    public Text distanceText; // Reference to the UI Text component

    // Update is called once per frame
    void Update()
    {
        if (targetObject != null && distanceText != null)
        {
            Vector3 cameraPosition = Camera.main.transform.position;
            Vector3 targetObjectPosition = targetObject.position;

            // Cast a ray from the camera towards the target object
            RaycastHit hit;
            if (Physics.Raycast(cameraPosition, targetObjectPosition - cameraPosition, out hit))
            {
                // Check if the ray intersects with the target object
                if (hit.collider.gameObject == targetObject.gameObject)
                {
                    float distance = hit.distance;

                    // Set the text of the UI Text component to display the distance
                    distanceText.text = "You are " + distance.ToString("F2") + " m away from the sensor";
                }
            }
        }
    }
}
