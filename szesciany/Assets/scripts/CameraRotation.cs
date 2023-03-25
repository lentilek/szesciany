using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = 2f;

    void Update()
    {
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
