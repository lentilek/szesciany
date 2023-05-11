using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMap2 : MonoBehaviour
{
    public PickableTypes meta;
    public string toLoad = "level_2";

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        
        if (playerInventory.numberOfPickupsMeta >= meta.toCollect)
        {
            
            SceneManager.LoadScene(toLoad);
        }

    }

}
