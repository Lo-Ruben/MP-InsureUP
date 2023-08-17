using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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
    public bool resetInt;
    public int insuranceBoughtCountCategory;

    private void Start()
    {
        GameObject ActionDeckManagerGameObject = GameObject.Find("GameManager");
        m_GameManager = ActionDeckManagerGameObject.GetComponent<GameManager>();
        getInsuranceInfo = gameObject.GetComponent<InsuranceDisplay>();
    }

    private void OnEnable()
    {
        resetInt = true;
        if (getInsuranceInfo != null && getInsuranceInfo.staticCardBack == true)
        {
            getInsuranceInfo.staticCardBack = false;
        }
    }
    private void OnDisable()
    {
        if (resetInt && otherInsurance1.resetInt &&  otherInsurance2.resetInt)
        {
            insuranceBoughtCountCategory = 0;
        }
    }

    private void Update()
    {
        int maxCategoryCount = Mathf.Max(insuranceBoughtCountCategory, otherInsurance1.insuranceBoughtCountCategory, otherInsurance2.insuranceBoughtCountCategory);
        insuranceBoughtCountCategory = maxCategoryCount;
        otherInsurance1.insuranceBoughtCountCategory = maxCategoryCount;
        otherInsurance2.insuranceBoughtCountCategory = maxCategoryCount;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        InsuranceBool();
    }

    void InsuranceBool()
    {
        string cardName = getInsuranceInfo.InsuranceData.cardName;

        switch (cardName)
        {
            case "Health Insurance T1": //The name of the card are these dont change
            case "Health Insurance T2":
            case "Health Insurance T3":

            case "Critical Illness Insurance T1":
            case "Critical Illness Insurance T2":
            case "Critical Illness Insurance T3":

            case "Life Insurance T1":
            case "Life Insurance T2":
            case "Life Insurance T3":

            case "Accident Insurance T1":
            case "Accident Insurance T2":
            case "Accident Insurance T3":
                ToggleCards();
                break;

            default:
                print("Incorrect insurance.");
                break;
        }
    }

    // Function to manage players buying shop card items
    void ToggleCards()
    {
        bool areOtherCardsBack = otherInsurance1.getInsuranceInfo.staticCardBack && otherInsurance2.getInsuranceInfo.staticCardBack;
        int cardCost = getInsuranceInfo.InsuranceData.cardCost;

        if (!areOtherCardsBack)
        {
            int remainingMoney = m_GameManager.money - cardCost;
            if (remainingMoney <= 0)
            {
                Debug.Log("Not Enough Money");
            }
            else
            {
                m_GameManager.money = remainingMoney;
                getInsuranceInfo.staticCardBack = false;
                otherInsurance1.getInsuranceInfo.staticCardBack = true;
                otherInsurance2.getInsuranceInfo.staticCardBack = true;

                m_GameManager.insuranceBoughtDictionary.Add(getInsuranceInfo.InsuranceData.insuranceCategory, getInsuranceInfo.InsuranceData.returnMoney);
                inventory.boughtInsrData.Add(getInsuranceInfo.InsuranceData);

                insuranceBoughtCountCategory++;
                otherInsurance1.insuranceBoughtCountCategory++;
                otherInsurance2.insuranceBoughtCountCategory++;

                resetInt = false;
            }
        }
        else
        {
            m_GameManager.money += cardCost;
            Debug.Log("Money: " + m_GameManager.money);

            getInsuranceInfo.staticCardBack = false;
            otherInsurance1.getInsuranceInfo.staticCardBack = false;
            otherInsurance2.getInsuranceInfo.staticCardBack = false;

            m_GameManager.insuranceBoughtDictionary.Remove(getInsuranceInfo.InsuranceData.insuranceCategory);

            insuranceBoughtCountCategory--;
            otherInsurance1.insuranceBoughtCountCategory--;
            otherInsurance2.insuranceBoughtCountCategory--;

            resetInt = true;
        }
    }

    public void ResetCardBack()
    {
        if (getInsuranceInfo.staticCardBack == true)
        {
            getInsuranceInfo.staticCardBack = false;
        }
    }
}