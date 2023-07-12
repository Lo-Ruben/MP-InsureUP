using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardTypeData")]
public class CardData : ScriptableObject
{
    public string cardName;
    public string cardDescription;

    //public int cardEffectDuration;
    public int cardCost;

    public Sprite cardImage;

}

