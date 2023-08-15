using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InsuranceInfo", menuName = "ScriptableObjects/InsuranceInfoData")]
public class InsuranceInfo : ScriptableObject
{
    // Text Info
    public string cardCounter;
    public string cardName;
    public Sprite cardImage;
}
