using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", menuName = "ScriptableObjects/InventoryData")]
public class InventoryData : ScriptableObject
{
    // Text Info
    public string cardCounter;
    public string cardName;
    public Sprite cardImage;
}
