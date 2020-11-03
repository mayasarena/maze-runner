using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private Animator anim;
    public float speed = 6f;
    public Transform cam;

    void Start() 
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float vertical = Mathf.Max(Input.GetAxis("Vertical"), 0); // Getting vertical axis input

        // Doing math things to move player relative to camera
        float camyrotation = Mathf.Deg2Rad * cam.transform.eulerAngles.y;
        float xdirection = Mathf.Sin(camyrotation);
        float zdirection = Mathf.Cos(camyrotation);
        Vector3 direction = new Vector3(xdirection, 0f, zdirection);

        if (direction != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation(direction); // Getting the direction of character
        }

        controller.Move(direction.normalized * speed * Time.deltaTime * vertical); // Moving the player

        anim.SetFloat("Speed", (Mathf.Abs(vertical) + Mathf.Abs(Input.GetAxis("Horizontal")))); // Set animator variable
    }
}
