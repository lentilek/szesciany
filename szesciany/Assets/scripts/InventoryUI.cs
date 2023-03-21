using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //biblioteka textu do UI

public class InventoryUI : MonoBehaviour //nazwa klasy + zaznaczenie ¿e jest publiczna
{
    private TextMeshProUGUI pickableText; //nazwa prywatnej zmiennej 

    // Start is called before the first frame update
    void Start()
    {
        pickableText = GetComponent<TextMeshProUGUI>(); //get text component and assign it to this field
    }

    public void UpdatePickableText(PlayerInventory playerInventory)
    {
        pickableText.text = playerInventory.NumberOfPickups.ToString();
    }
}
