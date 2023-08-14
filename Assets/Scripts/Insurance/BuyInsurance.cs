using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.
public class BuyInsurance : MonoBehaviour, IPointerDownHandler
{

    InsuranceDisplay getInsuranceInfo;
    [SerializeField]
    GameManager m_GameManager;

    // NEED TO MANUALLY SET THIS 
    // If i can refactor it it would be great
    // So I dont have to go crazy setting every individual insurance gameobject
    [SerializeField]
    BuyInsurance otherInsurance1;
    [SerializeField]
    BuyInsurance otherInsurance2;
    [SerializeField]
    Inventory inventory;

    private void Start()
    {
        GameObject ActionDeckManagerGameObject = GameObject.Find("GameManager");
        m_GameManager = ActionDeckManagerGameObject.GetComponent<GameManager>();
        getInsuranceInfo = gameObject.GetComponent<InsuranceDisplay>();
        inventory = GameObject.Find("Canvas").GetComponent<Inventory>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {

        InsuranceBool();
    }

    void InsuranceBool()
    {
        switch (getInsuranceInfo.InsuranceData.cardName)
        {
            // Health
            case "Health Insurance T1":
                ToggleCards();
                break;
            case "Health Insurance T2":
                ToggleCards();
                break;
            case "Health Insurance T3":
                ToggleCards();
                break;

            // Critical Illness
            case "Critical Illness Insurance T1":
                ToggleCards();
                break;
            case "Critical Illness Insurance T2":
                ToggleCards();
                break;
            case "Critical Illness Insurance T3":
                ToggleCards();
                break;

            // Life
            case "Life Insurance T1":
                ToggleCards();
                break;
            case "Life Insurance T2":
                ToggleCards();
                break;
            case "Life Insurance T3":
                ToggleCards();
                break;

            //Have not created card yet
            //Accident
            case "Accident Insurance T1":
                ToggleCards();
                break;
            case "Accident Insurance T2":
                ToggleCards();
                break;
            case "Accident Insurance T3":
                ToggleCards();
                break;


            default:
                print("Incorrect insurance.");
                break;
        }
    }

    // System to allow players to choose only buy 1 insurance per category
    void ToggleCards()
    {
        // On click, cause other cards to show backs
        if (otherInsurance1.getInsuranceInfo.staticCardBack == false && otherInsurance2.getInsuranceInfo.staticCardBack == false)
        {
            Debug.Log("Toggle other cards");
            this.getInsuranceInfo.staticCardBack = false;
            otherInsurance1.getInsuranceInfo.staticCardBack = !otherInsurance1.getInsuranceInfo.staticCardBack;
            otherInsurance2.getInsuranceInfo.staticCardBack = !otherInsurance2.getInsuranceInfo.staticCardBack;
            m_GameManager.insuranceBoughtDictionary.Add(getInsuranceInfo.InsuranceData.insuranceCategory, getInsuranceInfo.InsuranceData.returnMoney);
            Debug.Log("Category: " + getInsuranceInfo.InsuranceData.insuranceCategory + " Money: " + getInsuranceInfo.InsuranceData.returnMoney);
            inventory.boughtInsrData.Add(getInsuranceInfo.InsuranceData);
        }
        // Reset card backs
        else if (otherInsurance1.getInsuranceInfo.staticCardBack == true && otherInsurance2.getInsuranceInfo.staticCardBack == true)
        {
            Debug.Log("Reset");
            this.getInsuranceInfo.staticCardBack = false;
            otherInsurance1.getInsuranceInfo.staticCardBack = false;
            otherInsurance2.getInsuranceInfo.staticCardBack = false;
            m_GameManager.insuranceBoughtDictionary.Remove(getInsuranceInfo.InsuranceData.insuranceCategory);
            Debug.Log("Removed " + getInsuranceInfo.InsuranceData.insuranceCategory + " from dictionary");
            inventory.boughtInsrData.Remove(getInsuranceInfo.InsuranceData);
        }
    }
}
