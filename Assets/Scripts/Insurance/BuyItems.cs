using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyItems : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField] 
    private InsuranceDisplay getInsuranceInfo;
    public float distanceFromCamera = 10f;
    [SerializeField]
    Animator animator;

    int cardCostProsthetics;
    int discountedCardCostProsthetics;
    int newCardCostProsthetics;

    int cardCostMedCheck;
    int discountedCardCostMedCheck;
    int newCardCostMedCheck;

    public GameObject canvas; //here (drag it into both cards in inspector)

    private void OnEnable()
    {
        string cardName = getInsuranceInfo.InsuranceData.cardName;
        switch (cardName)
        {
            case "Medical Check Up":
                cardCostMedCheck = getInsuranceInfo.InsuranceData.originalCardCost;
                discountedCardCostMedCheck = cardCostMedCheck / 2;
                newCardCostMedCheck = gameManager.MedCheckCostChange(discountedCardCostMedCheck, cardCostMedCheck);
                getInsuranceInfo.InsuranceData.cardCost = newCardCostMedCheck;
                break;
            case "Prosthetic":
                cardCostProsthetics = getInsuranceInfo.InsuranceData.originalCardCost;
                discountedCardCostProsthetics = cardCostProsthetics / 2;
                newCardCostProsthetics = gameManager.ProstheticsCostChange(discountedCardCostProsthetics, cardCostProsthetics);
                getInsuranceInfo.InsuranceData.cardCost = newCardCostProsthetics;
                
                break;
        }

        
    }
    private void OnDisable()
    {
        getInsuranceInfo.InsuranceData.cardCost = getInsuranceInfo.InsuranceData.originalCardCost;
    }
    public void Update()
    {
        string cardName = getInsuranceInfo.InsuranceData.cardName;

        // Use an enum or constants for card names for better readability
        switch (cardName)
        {
            case "Medical Check Up":
                if (gameManager.health < gameManager.maxHealth)
                {
                    getInsuranceInfo.staticCardBack = false;
                }
                else if (gameManager.health <= gameManager.maxHealth)
                {
                    getInsuranceInfo.staticCardBack = true;
                }
                break;
            case "Prosthetic":
                if (gameManager.maxHealth < 5)
                {
                    getInsuranceInfo.staticCardBack = false;
                }
                else if (gameManager.maxHealth >= 5)
                {
                    getInsuranceInfo.staticCardBack = true;
                }
                break;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        BuyInsuranceItems();
    }

    private void BuyInsuranceItems()
    {
        string cardName = getInsuranceInfo.InsuranceData.cardName;

        // Use an enum or constants for card names for better readability
        switch (cardName) 
        {
            case "Medical Check Up": 
                if (gameManager.health < gameManager.maxHealth)
                {
                    getInsuranceInfo.staticCardBack = false;
                    gameManager.money -= getInsuranceInfo.InsuranceData.cardCost;
                    gameManager.health += 1;
                    CheckHealthInsurance(); //here
                    Debug.Log("Bought check up");
                    animator.SetTrigger("minus");
                }
                else if(gameManager.health <= gameManager.maxHealth)
                {
                    getInsuranceInfo.staticCardBack = true;
                }
                break;
            case "Prosthetic":
                if(gameManager.maxHealth < 5)
                {
                    getInsuranceInfo.staticCardBack = false;
                    gameManager.money -= getInsuranceInfo.InsuranceData.cardCost;
                    gameManager.maxHealth += 1;
                    CheckHealthInsurance(); //here
                    Debug.Log("Bought prosthetic");
                    animator.SetTrigger("minus");
                }   
                else if(gameManager.health >= 5)
                {
                    getInsuranceInfo.staticCardBack = true;
                }
                break;
        }

    }

    public void CheckHealthInsurance()
    {
        Inventory inventory = canvas.GetComponent<Inventory>();
        foreach (InsuranceData insurance in inventory.boughtInsrData)
        {
            if (insurance.insuranceCategory == "Health" 
                && gameManager.roundCounter > gameManager.boughtTurn
                && gameManager.healthInsuranceBool == false)
            {
                gameManager.money += insurance.returnMoney;
                gameManager.healthInsuranceBool = true;
                Debug.Log("it works! " + insurance.returnMoney);
            }
            else
            {
                Debug.Log("Boohoo!");
            }
        }
    }
}
