using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardTypeData")]
public class CardData : ScriptableObject
{
    // Text Info
    public string cardName;
    public string cardDescription;

    // Card Cost (If any)
    public int cardCost;

    // Family, Job and Personal aspects increase and decrease
    public int familyIncrease;
    public int jobIncrease;
    public int personalIncrease;

    // Card Duration
    public int cardEffectDuration;

    // For skills
    public bool testBool;


}

