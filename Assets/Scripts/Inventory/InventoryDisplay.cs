using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField]
    private InventoryData inventoryData;

    public InventoryData InventoryData
    {
        get { return inventoryData; }
        set { inventoryData = value; }
    }

    [SerializeField]
    Text cardNameText;
    [SerializeField]
    Text cardDescriptionText;
    [SerializeField]
    Image cardImage;

    //private void Start()
    //{
    //    DisplayInfo();
    //}

    private void Update()
    {
        DisplayInfo();
    }


    void DisplayInfo()
    {
        cardNameText.text = inventoryData.cardName;
        cardDescriptionText.text = inventoryData.cardCounter;
        cardImage.sprite = inventoryData.cardImage;
    }
}
