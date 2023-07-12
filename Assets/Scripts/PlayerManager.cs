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
        EndTurn();
    }

    void EndTurn()
    {
        jobLevelText.text = "LEVEL " + jobLevel.ToString();
        familyLevelText.text = "LEVEL " + familyLevel.ToString();
        personalLevelText.text = "LEVEL " + personalLevel.ToString();

        CalculateIncome(baseIncome);

        maxCardsHeld = familyLevel;

        if(personalLevel >= 5)
        {

        }
    }

    void CalculateIncome(int income)
    {
        int proffit = income * jobLevel;
        money += proffit;
    }

    
    void GameOver()
    {
        if(health<=0 || money <= 0)
        {
            Debug.Log("GameOver");
        }
    }
}
