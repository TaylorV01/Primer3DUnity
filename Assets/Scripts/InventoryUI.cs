using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI diamontText;
    // Start is called before the first frame update
    void Start()
    {
        diamontText = GetComponent<TextMeshProUGUI>();

    }

    public void UpdateDiamondText(PlayerInventory inventory)
    {
        diamontText.text = inventory.NumberOfCristals.ToString();
    }

}
