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

    // Card Image
    public Sprite cardImage;

    // Family, Job and Personal aspects increase and decrease
    public int familyIncrease;
    public int jobIncrease;
    public int personalIncrease;

    // Card Duration
    public int cardEffectDuration;

    //Discounts
    //Discount for Draw (Coupon Book)
    public bool drawDiscount = false;

    //Discount for Insurance Renewal (Clean Record)
    public bool renewalDiscount = false;

    //Discount for Insurance Upgrade (Add-On Deal)
    public bool upgradeDiscount = false;

    //Discount for Insurance Purchase (Referral)
    public bool insurancePurchaseDiscount = false;

    //Discount for Medical Treatment Item (Care Package) 
    public bool medicalTreatmentDiscount = false;

    //Discount for Prosthetics Item (Mass Production)
    public bool prostheticsDiscount = false;

}

