using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skale : MonoBehaviour
{
    private float timeSmall = 2f;
    private float betweenTime = 7f;
    private bool canBeSmall = true;

     void Update()
    {
         if (Input.GetKeyDown(KeyCode.Z) && canBeSmall)
        {
            transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            StartCoroutine(Small());
            StartCoroutine(CantBeSmall());
            canBeSmall= false;
        }
        
    }
    IEnumerator Small()
    {
        yield return new WaitForSeconds(timeSmall);
        transform.localScale = new Vector3(1, 1, 1);
    }
    IEnumerator CantBeSmall()
    {
        yield return new WaitForSeconds(betweenTime);
        canBeSmall= true;
    }
}


