using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [Header("Game UI")]
    public Text healthText;
    public Text moneyText;


    public Text jobLevelText;
    public Text familyLevelText;
    public Text personalLevelText;

    public Text goal1;
    public Text goal2;
    public Text goal3;

    public Text progress1;
    public Text progress2;
    public Text progress3;

    public Slider slider1;
    public Slider slider2;
    public Slider slider3;

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
        ShopGameObject.SetActive(false);
    }
    void Update()
    {
        setGoalTargetSlider();
        UpdateTextInfo();
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

    void UpdateTextInfo()
    {
        jobLevel = Mathf.Clamp(jobLevel, 0, 10);
        familyLevel = Mathf.Clamp(familyLevel, 0, 10);
        personalLevel = Mathf.Clamp(personalLevel, 0, 10);

        jobLevelText.text = jobLevel.ToString();
        familyLevelText.text = familyLevel.ToString();
        personalLevelText.text = personalLevel.ToString();

        healthText.text = "Health: " + health;
        moneyText.text = "Money: " + money;

        goal1.text = PlayerGoals.goalDataSaved1.goalName;
        goal2.text = PlayerGoals.goalDataSaved2.goalName;
        goal3.text = PlayerGoals.goalDataSaved3.goalName;

        progress1.text = PlayerGoals.goalDataSaved1.CurrentGoalInt + "/" + PlayerGoals.goalDataSaved1.GoalTargetInt;
        progress2.text = PlayerGoals.goalDataSaved2.CurrentGoalInt + "/" + PlayerGoals.goalDataSaved2.GoalTargetInt;
        progress3.text = PlayerGoals.goalDataSaved3.CurrentGoalInt + "/" + PlayerGoals.goalDataSaved3.GoalTargetInt;

        slider1.value = PlayerGoals.goalDataSaved1.CurrentGoalInt;
        slider2.value = PlayerGoals.goalDataSaved2.CurrentGoalInt;
        slider3.value = PlayerGoals.goalDataSaved3.CurrentGoalInt;
    }
    public void setGoalTargetSlider()
    {
        slider1.maxValue = PlayerGoals.goalDataSaved1.GoalTargetInt;
        slider2.maxValue = PlayerGoals.goalDataSaved2.GoalTargetInt;
        slider3.maxValue = PlayerGoals.goalDataSaved3.GoalTargetInt;

        slider1.value = PlayerGoals.goalDataSaved1.CurrentGoalInt;
        slider2.value = PlayerGoals.goalDataSaved2.CurrentGoalInt;
        slider3.value = PlayerGoals.goalDataSaved3.CurrentGoalInt;
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
                insuranceBoughtDictionary.Clear();
                if (crisisDisplay.CrisisInfo != null)
                {
                    crisisDisplay.CrisisInfo = null;
                }

                roundCounter++;
                CalculateIncome(baseIncome);

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

            else
            {
                familyLevel -= crisisDisplay.CrisisInfo.familyDecrease;
                jobLevel -= crisisDisplay.CrisisInfo.jobDecrease;
                personalLevel -= crisisDisplay.CrisisInfo.personalDecrease;
                health -= crisisDisplay.CrisisInfo.healthDecrease;
                money -= crisisDisplay.CrisisInfo.moneyDecrease;

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
            SceneManager.LoadScene(3);
        }
    }
}