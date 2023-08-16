using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CrisisData", menuName = "ScriptableObjects/CrisisTypeData")]

public class CrisisData : ScriptableObject
{
    // Text Info
    public string cardName;
    public string cardDescription;

    // Family, Job and Personal aspects decrease
    public int familyDecrease;
    public int jobDecrease;
    public int personalDecrease;
    public int healthDecrease;
    public int moneyDecrease;

    // Card Duration
    public int cardEffectDuration;

    // Insurance counter
    public string insuranceCounter;

    public RuntimeAnimatorController animatorController;
}
