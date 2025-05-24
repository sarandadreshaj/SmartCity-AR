using UnityEngine;

public class RotateWithCamera : MonoBehaviour
{
    public Transform wall;

    private void Update()
    {
        if (wall != null)
        {
            // Calculate the direction vector from the arrow to the wall.
            Vector3 directionToWall = wall.position - transform.position;

            // Calculate the rotation needed to point the arrow at the wall.
            Quaternion rotationToWall = Quaternion.LookRotation(directionToWall);

            // Apply the rotation to the arrow.
            transform.rotation = rotationToWall;
        }
    }
}
