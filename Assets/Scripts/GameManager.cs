using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [Header("Player stats")]
    private int health;
    public int increasedHealth;
    public int money;
    public int spentMoney;
    public int maxCardsHeld;

    public int timesProtected;

    [Header("Test Insurance fields")]
    // Insurance
    public GameObject ShopGameObject;

    // Personal aspects stats
    [Header("Personal aspects stats")]
    [SerializeField]
    int baseIncome;

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

    public Text moneyChangedText;


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
    private string sign;
    public Animator animator;

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

    public List<GameObject> discarded = new List<GameObject>();
    public List<GameObject> inHand = new List<GameObject>();
    public GameObject discardObj;
    public GameObject handObj;
    public PlayerDeck playerDeck;
    public AddPlayerCards addPlayerCards;
    public GameObject toughDecisionPanel;
    public GameObject canvas;

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
        maxCardsHeld = familyLevel;

        ShopGameObject.SetActive(false);

        discardObj = GameObject.Find("Discard Area");
        handObj = GameObject.Find("PlayerHand");
        playerDeck = GameObject.Find("ActionDeckManager").GetComponent<PlayerDeck>();
        addPlayerCards = handObj.GetComponent<AddPlayerCards>();
    }
    void Update()
    {
        setGoalTargetSlider();
        UpdateTextInfo();
        GameOver();
        PhaseCheck();
        UpdateHandAndDiscard();

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
        moneyText.text = " " + money;

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
        CycleHand(discardArea.cardDisplay);

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
                if(crisisDisplay.CrisisInfo.moneyDecrease < 0)
                {
                    sign = "+";
                }
                else
                {
                    sign = "-";
                }
                int moneyDecrease = Mathf.Abs(crisisDisplay.CrisisInfo.moneyDecrease);
                moneyChangedText.text = sign + moneyDecrease;
                moneyChangedText.gameObject.SetActive(true);
                animator.SetTrigger("Add");
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

    public void CycleHand(CardDisplay cardDisplay)
    {
        if (cardDisplay == null)
        {
            Debug.Log("No cardDisplay");
            return; // This will exit the function immediately
        }

        switch (cardDisplay.CardInfo.cardName)
        {
            case "Yesterday's Plans":

                //get a card from a random position in discard pile
                //add that card to hand
                if (discarded.Count > 0)
                {
                    int randInt = Random.Range(0, discarded.Count);
                    GameObject temp = discarded[randInt];
                    temp.transform.SetParent(handObj.transform);
                    //Allow card to be interactable
                    temp.GetComponent<Draggable>().isDraggingStop = false;
                    temp.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
                break;

            case "Screw it, we ball!":
                // Remove all cards from hand and shuffle
                // Then redraw same amount of cards

                int handCount = inHand.Count;
                foreach (GameObject handChild in inHand)
                {
                    playerDeck.deck.Add(handChild.GetComponent<CardDisplay>().CardInfo);
                }
                //shuffle
                playerDeck.Shuffle();
                //delete hand
                foreach (Transform childHand in handObj.transform)
                {
                    Destroy(childHand.gameObject);
                }
                //draw back up to same amount for free
                for (int i = 0; i < handCount; i++)
                {
                    addPlayerCards.SpawnCard();
                    money++;
                }
                break;

            case "Discovery":
                // Draw 1 card without paying
                addPlayerCards.SpawnCard();
                money++;
                break;

            case "Copycat":
                //get last card in discarded list
                //play it
                if (discarded.Count > 0)
                {
                    CardDisplay lastPlayed = discarded.Last().GetComponent<CardDisplay>();
                    UpdateStats(lastPlayed);
                    CycleHand(lastPlayed);
                }
                break;

            case "Restock":
                int cardsToAdd = maxCardsHeld - addPlayerCards.childCount;
                for (int i = 0; i < cardsToAdd; i++)
                {
                    addPlayerCards.SpawnCard();
                }
                break;

            case "Tough Choice":
                // Creates a selection page and shows 3 cards
                // When user selects a card 
                Debug.Log("Tough Choice");
                canvas.GetComponent<ToughDecision>().ShowDecisionPanelUI();
                break;

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

    void UpdateHandAndDiscard()
    {
        discarded.Clear();
        inHand.Clear();

        foreach (Transform discard in discardObj.transform)
        {
            discarded.Add(discard.gameObject);
        }
        foreach (Transform hand in handObj.transform)
        {
            inHand.Add(hand.gameObject);
        }
    }
}