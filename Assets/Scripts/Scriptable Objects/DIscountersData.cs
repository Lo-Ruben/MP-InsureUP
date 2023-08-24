using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiscountersData", menuName = "ScriptableObjects/DiscountersData")]
public class DiscountersData : ScriptableObject
{
    // Text Info
    public string cardName;
    public string cardDescription;

    // Card Cost (If any)
    public int cardCost;

    // Card Image
    public Sprite cardImage;

    //Discounts
    //Discount for Draw (Coupon Book)
    public bool drawDiscount;

    //Discount for Insurance Renewal (Clean Record)
    public bool renewalDiscount;

    //Discount for Insurance Upgrade (Add-On Deal)
    public bool upgradeDiscount;

    //Discount for Insurance Purchase (Referral)
    public bool insurancePurchaseDiscount;

    //Discount for Medical Treatment Item (Care Package) 
    public bool medicalTreatmentDiscount;

    //Discount for Prosthetics Item (Mass Production)
    public bool prostheticsDiscount;
}
