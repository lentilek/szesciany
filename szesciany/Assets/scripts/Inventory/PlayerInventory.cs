using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int numberOfPickupsMeta { get; private set; } //for the number of pickables collected { any other script can read the value but only THIS script can SET thhe value }
    public int numberOfPickupsGold { get; private set; }
    public int numberOfPickupsDoor { get; private set; }
    private LoadMap2 metaLM;
    public GameObject meta;
    public GameObject toOpen;

    private void Start()
    {
        metaLM = meta.GetComponent<LoadMap2>();
    }

    public UnityEvent<PlayerInventory> OnPickableCollected;
    public void PickupsCollectedMeta()
    {
        numberOfPickupsMeta++;
        if(numberOfPickupsMeta == metaLM.meta.toCollect)
        {
            SoundManagerScript.PlaySound("finishsound"); // powinno wtedy wydawaæ dŸwiêk finish -martyna
        }
        OnPickableCollected.Invoke(this);
    }

    public void CollectedGold()
    {
        numberOfPickupsGold++;
        OnPickableCollected.Invoke(this);
    }
    public void CollectedDoor()
    {
        numberOfPickupsDoor++;
        OnPickableCollected.Invoke(this);
    }
    public void OpenDoor()
    {
        toOpen.SetActive(false);
    }
}
