using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    // Player stats
    private int health;
    private int money;
    private int maxCardsHeld;

    // Insurance
    public GameObject InsuraceShop;
    public bool HealthInsurance { get; set; }
    public bool CriticalIllnessInsurance { get; set; }
    public bool EndownmentInsurance { get; set; }
    public bool LifeInsurance { get; set; }

    // Personal aspects stats
    [Header("Personal aspects stats")]
    [SerializeField]
    int baseIncome = 500;
    [SerializeField]
    private int maxPlayerHand;

    public int MaxPlayerHand 
    {
        get { return maxPlayerHand; }
        set { maxPlayerHand = value; }
    }

    // Game UI Text
    [Header("Game UI Text")]
    public Text healthText;
    public Text moneyText;

    public Text jobLevelText;
    public Text familyLevelText;
    public Text personalLevelText;
    public Text phaseText;

    [Header("Game Life Aspect Levels")]
    [SerializeField]
    private int jobLevel;
    [SerializeField]
    private int familyLevel;
    [SerializeField]
    private int personalLevel;
    [Header("Phase Debug")]
    [SerializeField]
    private int phaseInt;
    [SerializeField]
    private string phaseString;

    public int PhaseInt
    {
        get { return phaseInt; }
        set { phaseInt = value; }
    }

    // Discard Area
    [Header("Crisis Card")]
    [SerializeField]
    DropArea discardArea;

    // Crisis cards
    [SerializeField]
    CrisisDisplay crisisDisplay;

    public GameObject CrisisCardArea;


    void Start()
    {
        money = 500;
        health = 3;

        jobLevel = 5;
        familyLevel = 5;
        personalLevel = 5;
        phaseInt = 1;

        healthText.text = "Health: " + health;
        moneyText.text = "Money: " + money + "K";
        jobLevelText.text = "LEVEL " + jobLevel.ToString();
        familyLevelText.text = "LEVEL " + familyLevel.ToString();
        personalLevelText.text = "LEVEL " + personalLevel.ToString();
        InsuraceShop.SetActive(false);
    }

    void Update()
    {
        GameOver();
        PhaseCheck();
        //EndTurn();
    }

    // Updates the phase name based on the number
    // We have it this way so we can just have the integer increase instead of change the string
    public void PhaseCheck()
    {
        switch (phaseInt)
        {
            case 1:
                phaseString = "Draw";
                discardArea.enabled = false;
                ResetInsuranceBool();
                crisisDisplay.CrisisInfo = null;
                break;
            case 2:
                phaseString = "Action";
                discardArea.enabled = true;
                break;
            case 3:
                phaseString = "Buy";
                discardArea.enabled = false;
                InsuraceShop.SetActive(true);
                break;
            case 4:
                phaseString = "Effect";
                InsuraceShop.SetActive(false);
                ActivateCrisis();
                //Handle insurance and randomize drawing of crisis cards
                break;
            case 5:
                phaseInt = 1;
                break;
            default:
                Debug.Log("Out of phaseInt size");
                break;  
        }
    }

    
    public void PlayCard()
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

    void ResetInsuranceBool()
    {
        HealthInsurance = false;
        CriticalIllnessInsurance = false;
        EndownmentInsurance = false;
        LifeInsurance = false;
    }

    void CheckInsurance() 
    {
        //if ()
        //{

        //}
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

    // On button press function
    public void NextPhase()
    {
        phaseInt += 1;

    }

    void ActivateCrisis()
    {
        if (crisisDisplay.CrisisInfo != null)
        {
            CrisisCardArea.SetActive(true);
        }
        if (crisisDisplay.CrisisInfo == null)
        {
            CrisisCardArea.SetActive(false);
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
