using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfPickups { get; private set; } //for the number of pickables collected { any other script can read the value but only THIS script can SET thhe value }

    public void PickupsCollected()
    {
        NumberOfPickups++;

    }
}
