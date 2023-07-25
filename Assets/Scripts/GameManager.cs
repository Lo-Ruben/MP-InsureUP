using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Player stats
    private int health;
    private int money;
    private int maxCardsHeld;

    [Header("Test Insurance fields")]
    // Insurance
    public GameObject ShopGameObject;

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

    public Dictionary<string, int> insuranceBoughtDictionary = new Dictionary<string, int>();

    // Game UI Text
    [Header("Game UI Text")]
    public Text healthText;
    public Text moneyText;

    public Text jobLevelText;
    public Text familyLevelText;
    public Text personalLevelText;
    //Debugging
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

    public bool switchBool = false;


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
        ShopGameObject.SetActive(false);
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
                phaseText.text = "Draw";
                discardArea.enabled = false;
                break;
            case 2:
                phaseText.text = "Action";
                discardArea.enabled = true;
                break;
            case 3:
                phaseText.text = "Buy";
                discardArea.enabled = false;
                ShopGameObject.SetActive(true);
                break;
            case 4:
                phaseText.text = "Event";
                ShopGameObject.SetActive(false);
                ActivateCrisis();
                //Handle insurance interaction with crisis
                if (!switchBool)
                {
                    CheckInsurance();
                    switchBool = false;
                }
                break;
            // Reset
            case 5:
                phaseInt = 1;
                CrisisCardArea.SetActive(false);
                insuranceBoughtDictionary.Clear();
                if (crisisDisplay.CrisisInfo != null)
                {
                    crisisDisplay.CrisisInfo = null;
                }
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

        if (personalLevel >= 5)
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

    void CheckInsurance()
    {
        if (crisisDisplay.CrisisInfo != null)
        {
            // If player bought insurance
            // Check if player is encountering the same crisis as the insurance bought
            // Since its in update, adding of money may need to be tweaked
            if (insuranceBoughtDictionary.ContainsKey("Health") && crisisDisplay.CrisisInfo.insuranceCounter == "Health")
            {
                Debug.Log("Health Insurance money");
            }
            if (insuranceBoughtDictionary.ContainsKey("Critical Illness") && crisisDisplay.CrisisInfo.insuranceCounter == "Critical Illness")
            {
                Debug.Log("Critical Insurance money");
            }
            if (insuranceBoughtDictionary.ContainsKey("Endownent") && crisisDisplay.CrisisInfo.insuranceCounter == "Endownent")
            {
                Debug.Log("Endownent Insurance money");
            }
            if (insuranceBoughtDictionary.ContainsKey("Life") && crisisDisplay.CrisisInfo.insuranceCounter == "Life")
            {
                Debug.Log("Life Insurance money");
            }
            if (insuranceBoughtDictionary.ContainsKey("Accident") && crisisDisplay.CrisisInfo.insuranceCounter == "Accident")
            {
                Debug.Log("Accident Insurance money");
            }
        }

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
        if (health <= 0 || money <= 0)
        {
            Debug.Log("GameOver");
        }
    }
}
