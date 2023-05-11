using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = 2f;
    public float lookUpMax = 20;   
    public float lookUpMin = -60;
    public float lookLeft = -90;
    public float lookRight = 90;

    void Update()
    {
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        turn.x += Input.GetAxis("Mouse X") * sensitivity;

        turn.y = Mathf.Clamp(turn.y, lookUpMin, lookUpMax);
        turn.x = Mathf.Clamp(turn.x, lookLeft, lookRight);

        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
