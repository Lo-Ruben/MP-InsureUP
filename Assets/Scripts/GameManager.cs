using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Player stats
    public int health;
    public int maxHealth;
    public int increasedHealth;
    public int money;
    public int spentMoney;
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
    }

    public Dictionary<string, int> insuranceBoughtDictionary = new Dictionary<string, int>();

    // Game UI Text
    [Header("Game UI")]
    public Text healthText;
    public Text moneyText;
    public Text shopMoneyText;

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

    public GameObject phaseButton;


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
    public Animator textAnimation;
    public Animator coinAnimation;

    // Crisis cards
    [SerializeField]
    CrisisDisplay crisisDisplay;

    public GameObject CrisisCardArea;

    public bool hasHealthBeenModified = true;
    public bool hasCardCostBeenModified = true;
    public bool hasInsuranceCostBeenModified = false;
    public bool hasProstheticsCostBeenModified = false;
    public bool hasMedCheckCostBeenModified = false;

    public LifeAspectUI JobLifeAspect;
    public LifeAspectUI FamilyLifeAspect;
    public LifeAspectUI PersonalLifeAspect;
    // Organize goals into an Array
    GoalData[] goalDataArray = { PlayerGoals.goalDataSaved1, PlayerGoals.goalDataSaved2, PlayerGoals.goalDataSaved3 };

    public CardData cardData;

    public List<GameObject> discarded = new List<GameObject>();
    public List<GameObject> inHand = new List<GameObject>();
    public GameObject discardObj;
    public GameObject handObj;
    public PlayerDeck playerDeck;
    public AddPlayerCards addPlayerCards;
    public GameObject toughDecisionPanel;
    public GameObject canvas;
    public CardData cardPlayed;

    public bool discountedDraw = false;
    public bool discountedInsuranceCost = false;
    public bool discountedProstheticsCost = false;
    public bool discountedMedCheckCost = false;

    public int boughtTurn; //here
    public bool healthInsuranceBool; //here

    private void Awake()
    {
        money = 500;
        maxHealth = 5;
        health = maxHealth;
        JobLevel = 5;
        FamilyLevel = 5;
        PersonalLevel = 5;
        phaseInt = 1;
        roundCounter = 1;
        boughtTurn = 0; //here
        healthInsuranceBool = false; //here
}

    void Start()
    {
        ShopGameObject.SetActive(false);

        maxPlayerHand = familyLevel;

        discardObj = GameObject.Find("Discard Area");
        handObj = GameObject.Find("PlayerHand");
        playerDeck = GameObject.Find("ActionDeckManager").GetComponent<PlayerDeck>();
        addPlayerCards = handObj.GetComponent<AddPlayerCards>();
        cardPlayed = null;

    }
    void Update()
    {
        setGoalTargetSlider();
        UpdateTextInfo();
        GameOver();
        PhaseCheck();
        UpdateHandAndDiscard();

        JobLifeAspect.UpdateImage(JobLevel);
        FamilyLifeAspect.UpdateImage(FamilyLevel);
        PersonalLifeAspect.UpdateImage(PersonalLevel);

        if (goalDataArray[1] == null)
        {
            Debug.LogError("No Goals Found");
        }

        // Ensure max player hand matches family level
        maxPlayerHand = FamilyLevel;
    }
   
    void UpdateTextInfo()
    {
        JobLevel = Mathf.Clamp(JobLevel, 1, 10);
        FamilyLevel = Mathf.Clamp(FamilyLevel, 1, 10);
        PersonalLevel = Mathf.Clamp(PersonalLevel, 1, 10);

        jobLevelText.text = JobLevel.ToString();
        familyLevelText.text = FamilyLevel.ToString();
        personalLevelText.text = PersonalLevel.ToString();

        healthText.text = "Health: " + health + "/" + maxHealth;
        moneyText.text = "" + money;
        shopMoneyText.text = "" + money;

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
                phaseText.text = "Current Phase: Draw";
                discardArea.enabled = false;
                break;
            case 2:
                phaseText.text = "Current Phase: Action";
                if (hasCardCostBeenModified)
                {
                    addPlayerCards.drawCost = 4;
                    hasCardCostBeenModified = false;
                }
                if (hasInsuranceCostBeenModified)
                {
                    discountedInsuranceCost = true;
                    hasInsuranceCostBeenModified = false;
                }
                if (hasProstheticsCostBeenModified)
                {
                    discountedProstheticsCost = true;
                    hasProstheticsCostBeenModified = false;
                }
                if (hasMedCheckCostBeenModified)
                {
                    discountedMedCheckCost = true;
                    hasMedCheckCostBeenModified = false;
                }
                discardArea.enabled = true;
                break;
            case 3:
                phaseText.text = "Current Phase: Buy";
                discardArea.enabled = false;
                ShopGameObject.SetActive(true);
                break;
            case 4:
                phaseText.text = "Current Phase: Event";
                ShopGameObject.SetActive(false);
                ActivateCrisis();
                //Handle insurance interaction with crisis
                if (hasHealthBeenModified)
                {
                    if (PersonalLevel > 5)
                    {
                        if (health < 5)
                        {
                            health += 1;
                            increasedHealth++;
                            if(health > maxHealth)
                            {
                                health = maxHealth;
                            }
                        }

                        HighScoreSingleton.instance.AddScore(100);

                    }
                    if (PersonalLevel < 5)
                    {
                        health -= 1;

                        HighScoreSingleton.instance.DeductScore(100);
                    }
                    //Debug.Log(crisisDisplay.CrisisInfo != null);

                    hasHealthBeenModified = false;
                    StartCoroutine(CheckInsurance());
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
                discountedDraw = false;
                discountedInsuranceCost = false;
                discountedProstheticsCost = false;
                discountedMedCheckCost = false;
                roundCounter++;
                CalculateIncome(baseIncome);
                hasHealthBeenModified = true;
                hasCardCostBeenModified = true;
                healthInsuranceBool = false; //here
                break;
            default:
                Debug.Log("Out of phaseInt size");
                break;
        }
    }


    public void PlayCard()
    {
        UpdateStats(discardArea.cardData);
        CycleHand(discardArea.cardData);
        CheckDiscount();
        cardPlayed = discardArea.cardData;
        HighScoreSingleton.instance.AddScore(10);
    }

    public void CheckDiscount()
    {
        if (discardArea.cardData.drawDiscount == true)
        {
            Debug.Log("Discounted card has been placed");
            addPlayerCards.drawCost = 3;
            discountedDraw = true;
        }
        if (discardArea.cardData.insurancePurchaseDiscount == true)
        {
            Debug.Log("Discounted card has been placed");
            hasInsuranceCostBeenModified = true;
        }
        if(discardArea.cardData.prostheticsDiscount == true)
        {
            hasProstheticsCostBeenModified = true;
        }
        if(discardArea.cardData.medicalTreatmentDiscount == true)
        {
            hasMedCheckCostBeenModified = true;
        }
    }

    public int InsuranceCostChange(int discountedCardCost, int originalCardCost)
    {
        if (discountedInsuranceCost == true)
        {
            return discountedCardCost;
        }
        else
        {
            return originalCardCost;
        }
      
    }

    public int ProstheticsCostChange(int discountedCardCost, int originalCardCost)
    {
        if(discountedProstheticsCost == true)
        {
            return discountedCardCost;
        }
        else
        {
            return originalCardCost;
        }
    }

    public int MedCheckCostChange(int discountedCardCost, int originalCardCost)
    {
        if (discountedMedCheckCost == true)
        {
            return discountedCardCost;
        }
        else
        {
            return originalCardCost;
        }
    }

    
    void CalculateIncome(int income)
    {
        int proffit = income * JobLevel;
        MoneyDisplay(proffit);
        if (sign == "+" && proffit > 0)
        {
            StartCoroutine(IncomeMoneyCoroutine());
        }
        else
        {
            textAnimation.SetTrigger("Add");
            money += proffit;
        }

        void UpdateIncomeMoney()
        {
            textAnimation.SetTrigger("Add");
            money += proffit;
        }
        IEnumerator IncomeMoneyCoroutine()
        {
            yield return new WaitForSeconds(2f);
            UpdateIncomeMoney();
        }
    }

    // If player bought insurance
    // Check if player is encountering the same crisis as the insurance bought
    // Since its in update, adding of money may need to be tweaked

    IEnumerator CheckInsurance()
    {
        yield return new WaitForSeconds(0.1f);

        if (crisisDisplay.CrisisInfo != null)
        {
            string insuranceTypeCounter = crisisDisplay.CrisisInfo.insuranceCounter;

            if (insuranceBoughtDictionary.ContainsKey(insuranceTypeCounter))
            {
                int insuranceBenefit = insuranceBoughtDictionary[insuranceTypeCounter];
                Debug.Log(insuranceTypeCounter + " Insurance money");
                Debug.Log("Insurance Profit: " + insuranceBenefit);
                MoneyDisplay(insuranceBenefit);
                if (sign == "+" && insuranceBenefit > 0)
                {
                    StartCoroutine(InsuranceMoneyCoroutine());
                }
                else
                {
                    textAnimation.SetTrigger("Add");
                    money += insuranceBenefit;
                }
                timesProtected++;


                void UpdateInsuranceMoney()
                {
                    textAnimation.SetTrigger("Add");
                    money += insuranceBenefit;
                }
                IEnumerator InsuranceMoneyCoroutine()
                {
                    yield return new WaitForSeconds(2f);
                    UpdateInsuranceMoney();
                }
            }

            else
            {
                MoneyDisplay(crisisDisplay.CrisisInfo.moneyIntChange);

                FamilyLevel += crisisDisplay.CrisisInfo.familyIntChange;
                JobLevel += crisisDisplay.CrisisInfo.jobIntChange;
                PersonalLevel += crisisDisplay.CrisisInfo.personalIntChange;
                health += crisisDisplay.CrisisInfo.healthIntChange;
                if(health > maxHealth)
                {
                    health = maxHealth;
                }
                phaseButton.SetActive(false);
                if (sign == "+" && crisisDisplay.CrisisInfo.moneyIntChange >0)
                {
                    StartCoroutine(EventMoneyCoroutine());
                }
                else
                {
                    textAnimation.SetTrigger("Add");
                    money += crisisDisplay.CrisisInfo.moneyIntChange;
                    phaseButton.SetActive(true);
                }


                void updateMoneyEvent()
                {
                    textAnimation.SetTrigger("Add");
                    money += crisisDisplay.CrisisInfo.moneyIntChange;
                    phaseButton.SetActive(true);
                }
                IEnumerator EventMoneyCoroutine()
                {
                    yield return new WaitForSeconds(2f);
                    updateMoneyEvent();
                }
            }
        }
    }

    public void UpdateStats(CardData cardData)
    {
        if (cardData != null)
        {
            JobLevel += cardData.jobIncrease;
            FamilyLevel += cardData.familyIncrease;
            PersonalLevel += cardData.personalIncrease;
        }
        else
        {
            Debug.Log("No cardDisplay");
        }

    }

    public void CycleHand(CardData cardData)
    {
        if (cardData == null)
        {
            Debug.Log("No cardDisplay");
            return; // This will exit the function immediately
        }

        switch (cardData.cardName)
        {
            case "Yesterday's Plan":

                //get a card from a random position in discard pile
                //add that card to hand
                if (discarded.Count > 0)
                {
                    
                    int randInt = Random.Range(0, discarded.Count);
                    GameObject temp = discarded[randInt];
                    Debug.Log("balls: "+temp.GetComponent<CardDisplay>().CardInfo);
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
                if (cardPlayed != null)
                {
                    UpdateStats(cardPlayed);
                    CycleHand(cardPlayed);
                }
                break;

            case "Restock":
                int cardsToAdd = maxPlayerHand - addPlayerCards.childCount;
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

    // OnClick function for End Phase Button
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
            Debug.Log("GameOver: Lose");
            SceneManager.LoadScene(3);
        }
        if (money >= 50000)
        {
            Debug.Log("GameOver: Win");
            SceneManager.LoadScene(3);
        }
    }

    void MoneyDisplay(int moneyDifference)
    {
        Debug.Log(moneyDifference);
        if (moneyDifference < 0)
        {
            sign = "-";
        }
        else if(moneyDifference == 0)
        {
            sign = "+";
        }
        else if(moneyDifference >0)
        {
            sign = "+";
            coinAnimation.SetTrigger("Add");
        }
        int moneyDecrease = Mathf.Abs(moneyDifference);
        moneyChangedText.text = sign + moneyDecrease;
        moneyChangedText.gameObject.SetActive(true);
    }

    void UpdateHandAndDiscard()
    {
        discarded.Clear();
        inHand.Clear();

        foreach (Transform discard in discardObj.transform)
        {
            if(discard.gameObject.GetComponent<CardDisplay>() != null)
            {
                discarded.Add(discard.gameObject);
            }  
        }
        foreach (Transform hand in handObj.transform)
        {
            if (hand.gameObject.GetComponent<CardDisplay>() != null)
            {
                inHand.Add(hand.gameObject);
            }
        }
    }
}