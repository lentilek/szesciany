using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public float howLongOpen = 5f; // ile jest otwarte
    public GameObject toOpen;

    private void OnTriggerEnter(Collider other)
    {
        toOpen.SetActive(false);
        StartCoroutine(PressurePlateWait());
    }

    IEnumerator PressurePlateWait()
    {
        yield return new WaitForSeconds(howLongOpen);
        toOpen.SetActive(true);
    }
}
