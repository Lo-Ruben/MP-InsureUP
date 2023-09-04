using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject insuranceShop;
    public GameObject itemShop;
    public AudioClip select;
    public AudioSource audioSource;

    Text ShopHeader;

    public void InsuranceButton()
    {
        insuranceShop.SetActive(true);
        itemShop.SetActive(false);
        audioSource.clip = select;
        audioSource.Play();
    }
    public void ItemButton()
    {
        insuranceShop.SetActive(false);
        itemShop.SetActive(true);
        audioSource.clip = select;
        audioSource.Play();
    }
}
