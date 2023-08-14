using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InsuranceData", menuName = "ScriptableObjects/InsuranceTypeData")]
public class InsuranceData : ScriptableObject
{
    // Text Info
    public string cardName;
    public string cardDescription;

    // Card Cost
    public int cardCost;

    public Sprite cardImage;
    // Card Return
    public int returnMoney;

    public string insuranceCategory;
}
