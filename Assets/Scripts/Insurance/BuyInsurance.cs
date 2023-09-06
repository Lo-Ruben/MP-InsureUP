using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class BuyInsurance : MonoBehaviour, IPointerDownHandler
{
    // THIS SYSTEM NEEDS THESE ITEMS TO BE MANUALLY EDITED IN THE INSPECTOR
    // NEED TO REFORMAT THE ENTIRE SYSTEM
    [SerializeField] private InsuranceDisplay getInsuranceInfo;
    [SerializeField] private GameManager m_GameManager;
    [SerializeField] private BuyInsurance otherInsurance1;
    [SerializeField] private BuyInsurance otherInsurance2;
    [SerializeField] private Inventory inventory;
    [SerializeField]
    Animator MinusAnimator;
    public AudioSource audioSource;
    public AudioClip buySound;
    public Text moneyText;

    int cardCost;
    int discountedCardCost;
    int newCardCost;
    public int insuranceBoughtCountCategory;

    public bool resetInt;

    private void Awake()
    {
        GetGameManager();
    }

    private void OnEnable()
    {
        UpdateCounts();
        cardCost = getInsuranceInfo.InsuranceData.originalCardCost;
        discountedCardCost = cardCost / 2;
        newCardCost = m_GameManager.InsuranceCostChange(discountedCardCost, cardCost);
        getInsuranceInfo.InsuranceData.cardCost = newCardCost;

        resetInt = true;

        if (otherInsurance1.getInsuranceInfo.staticCardBack == true && otherInsurance2.getInsuranceInfo.staticCardBack == true)
        {
            Debug.Log("Enable Add");
            insuranceBoughtCountCategory += 1;
        }
        else
        {
            insuranceBoughtCountCategory = 0;
        }
    }
    private void OnDisable()
    {
        getInsuranceInfo.InsuranceData.cardCost = getInsuranceInfo.InsuranceData.originalCardCost;
        
    }

    private void GetGameManager()
    {
        GameObject actionDeckManagerGameObject = GameObject.Find("GameManager");
        if (actionDeckManagerGameObject != null)
        {
            m_GameManager = actionDeckManagerGameObject.GetComponent<GameManager>();
        }
        else
        {
            Debug.LogError("GameManager object not found!");
        }
    }

    private void UpdateCounts()
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

    private void InsuranceBool()
    {
        string cardName = getInsuranceInfo.InsuranceData.cardName;
        
        // Use an enum or constants for card names for better readability
        switch (cardName)
        {
            case "Health Insurance T1":
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
                Debug.Log("Incorrect insurance.");
                break;
        }
    }

    private void ToggleCards()
    {
        int remainingMoney = m_GameManager.money - cardCost;
        bool areOtherCardsBack = otherInsurance1.getInsuranceInfo.staticCardBack && otherInsurance2.getInsuranceInfo.staticCardBack;

        if (!areOtherCardsBack)
        {
            if (remainingMoney <= 0)
            {
                Debug.Log("Not Enough Money");
            }
            else
            {
                m_GameManager.money -= getInsuranceInfo.InsuranceData.cardCost;
                getInsuranceInfo.InsuranceData.boughtTurn = m_GameManager.roundCounter;
                moneyText.text = "-$" + getInsuranceInfo.InsuranceData.cardCost.ToString();
                MinusAnimator.SetTrigger("minus");
                getInsuranceInfo.staticCardBack = false;
                otherInsurance1.getInsuranceInfo.staticCardBack = true;
                otherInsurance2.getInsuranceInfo.staticCardBack = true;

                otherInsurance1.GetComponent<CanvasGroup>().blocksRaycasts = false;
                otherInsurance2.GetComponent<CanvasGroup>().blocksRaycasts = false;

                m_GameManager.insuranceBoughtDictionary.Add(getInsuranceInfo.InsuranceData.insuranceCategory, getInsuranceInfo.InsuranceData.returnMoney);
                inventory.boughtInsrData.Add(getInsuranceInfo.InsuranceData);

                insuranceBoughtCountCategory++;
                otherInsurance1.insuranceBoughtCountCategory++;
                otherInsurance2.insuranceBoughtCountCategory++;

                resetInt = false;

                audioSource.clip = buySound;
                audioSource.Play();

                //for health insurance
                /*
                if (getInsuranceInfo.InsuranceData.insuranceCategory == "Health")
                {
                    m_GameManager.boughtTurn = m_GameManager.roundCounter;
                }
                */
            }
        }
        else
        {
            foreach (InsuranceData insuranceData in inventory.boughtInsrData)
            {
                if (getInsuranceInfo.InsuranceData == insuranceData && getInsuranceInfo.InsuranceData.boughtTurn == m_GameManager.roundCounter)
                {
                    m_GameManager.money += getInsuranceInfo.InsuranceData.cardCost;
                }
            }

            moneyText.text = "+$" + getInsuranceInfo.InsuranceData.cardCost.ToString();
            MinusAnimator.SetTrigger("minus");
            getInsuranceInfo.staticCardBack = false;
            otherInsurance1.getInsuranceInfo.staticCardBack = false;
            otherInsurance2.getInsuranceInfo.staticCardBack = false;

            otherInsurance1.GetComponent<CanvasGroup>().blocksRaycasts = true;
            otherInsurance2.GetComponent<CanvasGroup>().blocksRaycasts = true;

            m_GameManager.insuranceBoughtDictionary.Remove(getInsuranceInfo.InsuranceData.insuranceCategory);
            inventory.boughtInsrData.Remove(getInsuranceInfo.InsuranceData);

            insuranceBoughtCountCategory--;
            otherInsurance1.insuranceBoughtCountCategory--;
            otherInsurance2.insuranceBoughtCountCategory--;


            resetInt = true;
        }

        UpdateCounts();
    }

    public void ResetCardBack()
    {
        if (getInsuranceInfo.staticCardBack == true)
        {
            getInsuranceInfo.staticCardBack = false;
        }
    }
    
}