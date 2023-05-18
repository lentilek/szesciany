using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Timeline.AnimationPlayableAsset;

public class CameraControl : MonoBehaviour
{
    public Transform camTarget;
    public float pLerp = .02f;
    public float rLerp = .01f;
    public LoadMap2 LM;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, camTarget.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp);


        if (Input.GetMouseButtonDown(0) && !LM.UI)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if(LM.UI)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
