using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    [SerializeField]
    GameObject insuranceScroll;
    [SerializeField]
    GameObject itemScroll;

    public void ToggleShopInsurance()
    {
        insuranceScroll.SetActive(true);
        itemScroll.SetActive(false);
    }
    public void ToggleShopItem()
    {
        insuranceScroll.SetActive(false);
        itemScroll.SetActive(true);
    }
}
