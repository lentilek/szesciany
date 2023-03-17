using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI pickableText;

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
