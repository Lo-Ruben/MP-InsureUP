using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Player stats
    private int health;
    public int money;
    private int maxCardsHeld;

    [Header("Test Insurance fields")]
    // Insurance
    public GameObject ShopGameObject;

    // Personal aspects stats
    [Header("Personal aspects stats")]
    [SerializeField]
    int baseIncome;
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
    [SerializeField]
    private int JobLevel;
    public int jobLevel
    {
        get { return JobLevel; }
        set { JobLevel = value; }
    }
    [SerializeField]
    private int FamilyLevel;
    public int familyLevel
    {
        get { return FamilyLevel; }
        set { FamilyLevel = value; }
    }
    [SerializeField]
    private int PersonalLevel;
    public int personalLevel
    {
        get { return PersonalLevel; }
        set { PersonalLevel = value; }
    }

    [Header("Phase Debug")]

    public int roundCounter;

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

    public bool switchBool = true;

    public LifeAspectUI JobLifeAspect;
    public LifeAspectUI FamilyLifeAspect;
    public LifeAspectUI PersonalLifeAspect;
    // Organize goals into an Array
    GoalData[] goalDataArray = { PlayerGoals.goalDataSaved1, PlayerGoals.goalDataSaved2, PlayerGoals.goalDataSaved3 };

    private void Awake()
    {
        money = 500;
        health = 3;
        JobLevel = 5;
        FamilyLevel = 5;
        PersonalLevel = 5;
        phaseInt = 1;
        roundCounter = 1;
    }
    void Start()
    {
        healthText.text = "Health: " + health;
        moneyText.text = "Money: " + money;
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
        TextUpdate();
        GameOver();
        PhaseCheck();

        JobLifeAspect.UpdateJobImage();
        FamilyLifeAspect.UpdateFamilyImage();
        PersonalLifeAspect.UpdatePersonalImage();

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


                if (switchBool)
                {
                    if (personalLevel > 5)
                    {
                        health += 1;
                        HighScoreSingleton.instance.AddScore(100);

                    }
                    if (personalLevel < 5)
                    {
                        health -= 1;
                        HighScoreSingleton.instance.DeductScore(100);
                    }
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

                roundCounter++;
                //CalculateIncome(baseIncome);

                switchBool = true;
                break;
            default:
                Debug.Log("Out of phaseInt size");
                break;
        }
    }


    public void PlayCard()
    {
        UpdateStats(discardArea.cardDisplay);

        maxCardsHeld = familyLevel;
        HighScoreSingleton.instance.AddScore(10);
    }

    void CalculateIncome(int income)
    {
        Debug.Log("CalculateIncome");
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
                int insuranceBenefit = insuranceBoughtDictionary["Health"];
                Debug.Log("Insurance Proffit: " + insuranceBenefit);
                money += insuranceBenefit;
            }
            if (insuranceBoughtDictionary.ContainsKey("Critical Illness") && crisisDisplay.CrisisInfo.insuranceCounter == "Critical Illness")
            {
                Debug.Log("Critical Insurance money");
                int insuranceBenefit = insuranceBoughtDictionary["Critical Illness"];
                money += insuranceBenefit;
            }
            if (insuranceBoughtDictionary.ContainsKey("Life") && crisisDisplay.CrisisInfo.insuranceCounter == "Life")
            {
                Debug.Log("Life Insurance money");
                int insuranceBenefit = insuranceBoughtDictionary["Life"];
                money += insuranceBenefit;
            }
            if (insuranceBoughtDictionary.ContainsKey("Accident") && crisisDisplay.CrisisInfo.insuranceCounter == "Accident")
            {
                Debug.Log("Accident Insurance money");
                int insuranceBenefit = insuranceBoughtDictionary["Accident"];
                money += insuranceBenefit;
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
            Debug.Log("Player Loses");
            SceneManager.LoadScene(3);
        }
    }

    void TextUpdate()
    {
        if (jobLevel > 10)
        {
            jobLevel = 10;
        }
        if (familyLevel > 10)
        {
            familyLevel = 10;
        }
        if (personalLevel > 10)
        {
            personalLevel = 10;
        }
        if (jobLevel < 0)
        {
            jobLevel = 0;
        }
        if (familyLevel < 0)
        {
            familyLevel = 0;
        }
        if (personalLevel < 0)
        {
            personalLevel = 0;
        }

        jobLevelText.text = jobLevel.ToString();
        familyLevelText.text = familyLevel.ToString();
        personalLevelText.text = personalLevel.ToString();

        healthText.text = "Health: " + health;
        moneyText.text = "Money: " + money;
    }
}
