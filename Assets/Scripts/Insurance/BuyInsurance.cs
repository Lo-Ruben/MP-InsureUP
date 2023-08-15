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

    public bool resetInt;
    public int continuousInsuranceTurnInt;

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
        if (resetInt)
        {
            continuousInsuranceTurnInt = 0;
        }
        else
        {
            continuousInsuranceTurnInt = Mathf.Max(continuousInsuranceTurnInt, otherInsurance1.continuousInsuranceTurnInt, otherInsurance2.continuousInsuranceTurnInt);
            Debug.Log(continuousInsuranceTurnInt);

        }

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
            case "Health1":
            case "Health2":
            case "Health3":

            case "Critical Illness1":
            case "Critical Illness2":
            case "Critical Illness3":

            case "Life1":
            case "Life2":
            case "Life3":

            case "Accident1":
            case "Accident2":
            case "Accident3":
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
                continuousInsuranceTurnInt++;
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
            continuousInsuranceTurnInt--;
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