using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform cam; //reference to camera
    public Transform playerRoot; //rotating the actual character not just the body
                                 //
    public float sensitivity;

    float rotX;
    float rotY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float x = Input.GetAxis("Mouse X") * sensitivity;
        float y = Input.GetAxis("Mouse Y") * sensitivity;

        rotX -= y;
        rotY += x;

        //rotating our camera and player root

        playerRoot.rotation = Quaternion.Euler(0, rotY, 0); //player (root) rotates on the Y axis
        cam.rotation = Quaternion.Euler(rotX, rotY, 0); //camera rotates in the X axis

    }
}
