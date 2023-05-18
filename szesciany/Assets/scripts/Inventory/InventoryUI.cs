using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //biblioteka textu do UI

public class InventoryUI : MonoBehaviour //nazwa klasy + zaznaczenie ¿e jest publiczna
{
    public TextMeshProUGUI pickableText; //nazwa prywatnej zmiennej 
    public TextMeshProUGUI pickableTextGold;
    public TextMeshProUGUI pickableTextDoor;

    // Start is called before the first frame update
    void Start()
    {
        //pickableText = GetComponent<TextMeshProUGUI>(); //get text component and assign it to this field
    }

    public void UpdatePickableText(PlayerInventory playerInventory)
    {
        pickableText.text = playerInventory.numberOfPickupsMeta.ToString();
    }
    public void UpdatePickableTextGold(PlayerInventory playerInventory)
    {
        pickableTextGold.text = playerInventory.numberOfPickupsGold.ToString();
    }
    public void UpdatePickableTextDoor(PlayerInventory playerInventory)
    {
        pickableTextDoor.text = playerInventory.numberOfPickupsDoor.ToString();
    }
}
