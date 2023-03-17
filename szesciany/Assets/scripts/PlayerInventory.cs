using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfPickups { get; private set; } //for the number of pickables collected { any other script can read the value but only THIS script can SET thhe value }

    public UnityEvent<PlayerInventory> OnPickableCollected;
    public void PickupsCollected()
    {
        NumberOfPickups++;
        OnPickableCollected.Invoke(this);
    }
}
