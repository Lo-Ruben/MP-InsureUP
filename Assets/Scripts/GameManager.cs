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

    public Text goal1;
    public Text goal2;
    public Text goal3;

    //Debugging
    public Text phaseText;

    [Header("Game Life Aspect Levels")]
    private int JobLevel;
    public int jobLevel
    {
        get { return JobLevel; }
    }

    private int FamilyLevel;
    public int familyLevel
    {
        get { return FamilyLevel; }
    }
    private int PersonalLevel;
    public int personalLevel
    {
        get { return PersonalLevel; }
    }

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

    public LifeAspectUI JobLifeAspect;
    public LifeAspectUI FamilyLifeAspect;
    public LifeAspectUI PersonalLifeAspect;
    // Organize goals into an Array
    GoalData[] goalDataArray = { PlayerGoals.goalDataSaved1, PlayerGoals.goalDataSaved2, PlayerGoals.goalDataSaved3 };

    void Start()
    {
        money = 500;
        health = 3;

        JobLevel = 5;
        FamilyLevel = 5;
        PersonalLevel = 5;
        phaseInt = 1;

        healthText.text = "Health: " + health;
        moneyText.text = "Money: " + money + "K";
        jobLevelText.text = jobLevel.ToString();
        familyLevelText.text = familyLevel.ToString();
        personalLevelText.text = personalLevel.ToString();
        ShopGameObject.SetActive(false);

        // Display game goal's
        // Need to find a way to display goal name description on UI

        goal1.text = PlayerGoals.goalDataSaved1.goalName;
        goal2.text = PlayerGoals.goalDataSaved2.goalName;
        goal3.text = PlayerGoals.goalDataSaved3.goalName;
    }

    void Update()
    {
        GameOver();
        PhaseCheck();

        if (goalDataArray[1] == null)
        {
            Debug.LogError("No Goals Found");
        }

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
        jobLevelText.text = jobLevel.ToString();
        familyLevelText.text = familyLevel.ToString();
        personalLevelText.text = personalLevel.ToString();
        JobLifeAspect.UpdateJobImage();
        FamilyLifeAspect.UpdateFamilyImage();
        PersonalLifeAspect.UpdatePersonalImage();
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
            JobLevel += cardDisplay.CardInfo.jobIncrease;
            FamilyLevel += cardDisplay.CardInfo.familyIncrease;
            PersonalLevel += cardDisplay.CardInfo.personalIncrease;
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
