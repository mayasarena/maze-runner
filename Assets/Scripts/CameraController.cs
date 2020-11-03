using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; 
    public float smooth = 0.5f;
    public float offset = 2.3f;
    public float yoffset = 3.7f;
    public float rotationSpeed = 1f;

    void Update()
    {
        UpdateRotation();
        SetPosition();
    }

    void SetPosition() 
    {
        // Doing math things to figure out respective offsets
        float yrotation = Mathf.Deg2Rad * transform.eulerAngles.y;
        float xoffset = -1 * Mathf.Sin(yrotation) * offset; // Getting x offset based on the y rotation
        float zoffset = -1 * Mathf.Cos(yrotation) * offset; // Getting z offset based on the z rotation

        // Setting the new position
        transform.position = new Vector3(
            player.transform.position.x + xoffset,
            player.transform.position.y + yoffset,
            player.transform.position.z + zoffset
        );
    }

    void UpdateRotation()
    {
        // Updating the rotation of the camera based on the horizontal input
        float horizontal = Input.GetAxis("Horizontal");
        transform.rotation = Quaternion.Euler(
            transform.eulerAngles.x, 
            transform.eulerAngles.y + horizontal * rotationSpeed, // Camera rotates on y axis, so changes are applied here
            transform.eulerAngles.z
        );
    }
}
