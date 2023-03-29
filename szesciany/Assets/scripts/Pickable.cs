using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) //detect collisions between pickable objects and the player
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>(); // to check if the collission is with the player, get the player's inventory component from the object that has been collided with

        if (playerInventory != null)
        {
            SoundManagerScript.PlaySound("collectsound"); // powinno wtedy wydawaæ dŸwiêk zebrania -martyna
            playerInventory.PickupsCollected();
            gameObject.SetActive(false); //set pickable as inactive once collected // so once it collides and is collected by player it increases the number of pickables collected and then gets deactivated
        }

    }  
}
