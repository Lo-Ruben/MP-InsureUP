using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject insuranceShop;
    public GameObject itemShop;

    Text ShopHeader;

    public void InsuranceButton()
    {
        insuranceShop.SetActive(true);
        itemShop.SetActive(false);
    }
    public void ItemButton()
    {
        insuranceShop.SetActive(false);
        itemShop.SetActive(true);
    }
}
