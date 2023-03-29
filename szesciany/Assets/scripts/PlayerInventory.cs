using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfPickups { get; private set; } //for the number of pickables collected { any other script can read the value but only THIS script can SET thhe value }

    private LoadMap2 metaLM;
    public GameObject meta;

    private void Start()
    {
        metaLM = meta.GetComponent<LoadMap2>();
    }

    public UnityEvent<PlayerInventory> OnPickableCollected;
    public void PickupsCollected()
    {
        NumberOfPickups++;
        if(NumberOfPickups == metaLM.neededPickUps)
        {
            SoundManagerScript.PlaySound("finishsound"); // powinno wtedy wydawaæ dŸwiêk finish -martyna
        }
        OnPickableCollected.Invoke(this);
    }
}
