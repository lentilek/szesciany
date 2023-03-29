using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public float howLongOpen = 5; // ile jest otwarte
    public float timer = 0; // ile czasu zosta³o do zamkniêcia
    public GameObject toOpen;
    public bool isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        isOpen= true;
        timer = 0;
        toOpen.SetActive(false);
    }
    private void Update()
    {
        if(isOpen)
        {
            timer += Time.deltaTime;
            if(timer >= howLongOpen)
            {
                isOpen = false;
                toOpen.SetActive(true);
            }
        }
    }
}
