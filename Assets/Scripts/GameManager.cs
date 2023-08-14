using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Player stats
    private int health;
    public int increasedHealth;
    public int money;
    public int spentMoney;
    private int maxCardsHeld;

    public int timesProtected;

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
                        if (health < 5)
                        {
                            health += 1;
                            increasedHealth++;
                        }
                        
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


                if (insuranceBoughtDictionary != null)
                {

                }

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

    // If player bought insurance
    // Check if player is encountering the same crisis as the insurance bought
    // Since its in update, adding of money may need to be tweaked
    void CheckInsurance()
    {
        if (crisisDisplay.CrisisInfo != null)
        {
            string insuranceType = crisisDisplay.CrisisInfo.insuranceCounter;

            if (insuranceBoughtDictionary.ContainsKey(insuranceType))
            {
                int insuranceBenefit = insuranceBoughtDictionary[insuranceType];
                Debug.Log(insuranceType + " Insurance money");
                Debug.Log("Insurance Profit: " + insuranceBenefit);
                money += insuranceBenefit;
                timesProtected++;
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
        jobLevel = Mathf.Clamp(jobLevel, 0, 10);
        familyLevel = Mathf.Clamp(familyLevel, 0, 10);
        personalLevel = Mathf.Clamp(personalLevel, 0, 10);

        jobLevelText.text = jobLevel.ToString();
        familyLevelText.text = familyLevel.ToString();
        personalLevelText.text = personalLevel.ToString();

        healthText.text = "Health: " + health;
        moneyText.text = "Money: " + money;
    }
}
