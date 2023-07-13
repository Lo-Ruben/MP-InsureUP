using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardTypeData")]
public class CardData : ScriptableObject
{
    public string cardName;
    public string cardDescription;
    public int cardCost;

    public Sprite cardImage;

    public int familyIncrease;
    public int jobIncrease;
    public int personalIncrease;
    public int cardEffectDuration;

    public bool testBool;


}

