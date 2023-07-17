using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private int health;
    private int money;
    private int maxCardsHeld;

    int baseIncome = 500;

    [SerializeField]
    private int jobLevel;
    [SerializeField]
    private int familyLevel;
    [SerializeField]
    private int personalLevel;


    public Text healthText;
    public Text moneyText;

    public Text jobLevelText;
    public Text familyLevelText;
    public Text personalLevelText;

    [SerializeField]
    DropArea discardArea;


    void Start()
    {
        money = 500;
        health = 3;

        jobLevel = 5;
        familyLevel = 5;
        personalLevel = 5;

        healthText.text = "Health: " + health;
        moneyText.text = "Money: " + money + "K";
    }

    void Update()
    {
        GameOver();
        //EndTurn();
    }

    public void EndTurn()
    {
        UpdateStats(discardArea.cardDisplay);
        jobLevelText.text = "LEVEL " + jobLevel.ToString();
        familyLevelText.text = "LEVEL " + familyLevel.ToString();
        personalLevelText.text = "LEVEL " + personalLevel.ToString();

        CalculateIncome(baseIncome);

        maxCardsHeld = familyLevel;

        if(personalLevel >= 5)
        {
            // Gain health
        }
        if (personalLevel < 5)
        {
            // Lose health
        }


    }

    void CalculateIncome(int income)
    {
        int proffit = income * jobLevel;
        money += proffit;
    }

    public void UpdateStats(CardDisplay cardDisplay)
    {
        if (cardDisplay != null)
        {
            jobLevel += cardDisplay.CardInfo.jobIncrease;
            familyLevel += cardDisplay.CardInfo.familyIncrease;
            personalLevel += cardDisplay.CardInfo.personalIncrease;
        }
        else
        {
            Debug.Log("No cardDisplay");
        }
        
    }


    void GameOver()
    {
        if(health<=0 || money <= 0)
        {
            Debug.Log("GameOver");
        }
    }
}
