using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMap2 : MonoBehaviour
{
    public int neededPickUps = 3;
    public string toLoad = "level_2";

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory.NumberOfPickups >= neededPickUps)
        {
            SceneManager.LoadScene(toLoad);
        }

    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
