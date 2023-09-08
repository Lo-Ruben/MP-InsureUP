using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEvent : MonoBehaviour
{
    [SerializeField]
    GameManager m_gameManager;
    [SerializeField]
    AddPlayerCards m_addPlayerCards;
    [SerializeField]
    DropArea m_dropArea;

    EventUpdate m_eventUpdate;

    [SerializeField]
    BuyInsurance buyInsuranceHealth;
    [SerializeField]
    BuyInsurance buyInsuranceAccident;
    [SerializeField]
    BuyInsurance buyInsuranceCritical;
    [SerializeField]
    BuyInsurance buyInsuranceLife;

    private void Start()
    {
        m_eventUpdate = GetComponent<EventUpdate>();
        m_eventUpdate.CheckGoals += GoalCheck1_Conditions;
        m_eventUpdate.CheckGoals += GoalCheck2_Conditions;
        m_eventUpdate.CheckGoals += GoalCheck3_Conditions;
    }

    private void GoalCheck1_Conditions(object sender, System.EventArgs e)
    {
        GoalData GoalData1 = PlayerGoals.goalDataSaved1;
        string goalName = GoalData1.name;

        if (CheckGoal(goalName, GoalData1))
        {
            m_gameManager.goal1.color = Color.yellow;
            UnsubscribeGoalCheck1();
        }
    }

    private void GoalCheck2_Conditions(object sender, System.EventArgs e)
    {
        GoalData GoalData2 = PlayerGoals.goalDataSaved2;
        string goalName = GoalData2.name;

        if (CheckGoal(goalName, GoalData2))
        {
            m_gameManager.goal2.color = Color.yellow;
            UnsubscribeGoalCheck2();
        }
    }

    private void GoalCheck3_Conditions(object sender, System.EventArgs e)
    {
        GoalData GoalData3 = PlayerGoals.goalDataSaved3;
        string goalName = GoalData3.name;

        if (CheckGoal(goalName, GoalData3))
        {
            m_gameManager.goal3.color = Color.yellow;
            UnsubscribeGoalCheck3();
        }
    }

    private bool CheckGoal(string goalName, GoalData goalData)
    {
        switch (goalName)
        {
            case "Goal1": return Goal1(goalData);
            case "Goal2": return Goal2(goalData);
            case "Goal3": return Goal3(goalData);
            case "Goal4": return Goal4(goalData);
            case "Goal5": return Goal5(goalData);
            case "Goal6": return Goal6(goalData);
            case "Goal7": return Goal7(goalData);
            case "Goal8": return Goal8(goalData);
            case "Goal9": return Goal9(goalData);
            case "Goal10": return Goal10(goalData);
            default: return false;
        }
    }

    // Functions to prevent further checks once goals have been accomplished
    void UnsubscribeGoalCheck1()
    {
        m_eventUpdate.CheckGoals -= GoalCheck1_Conditions;
    }
    void UnsubscribeGoalCheck2()
    {
        m_eventUpdate.CheckGoals -= GoalCheck2_Conditions;
    }
    void UnsubscribeGoalCheck3()
    {
        m_eventUpdate.CheckGoals -= GoalCheck3_Conditions;
    }

    // Goal Logic
    bool Goal1(GoalData goalData)
    {
        int MaxGoal = 10;
        SetGoalInt(goalData, m_gameManager.jobLevel, MaxGoal);
        
        //Reach 10 pts for work
        if (m_gameManager.jobLevel >= MaxGoal)
        {
            Debug.Log("Goal1 Got");

            return true;
        }
        else { return false; }
    }
    bool Goal2(GoalData goalData)
    {
        int MaxGoal = 10;
        SetGoalInt(goalData, m_gameManager.personalLevel, MaxGoal);

        //Reach 10 pts for personal
        if (m_gameManager.personalLevel >= MaxGoal)
        {
            Debug.Log("Goal2 Got");

            return true;
        }
        else { return false; }
    }
    bool Goal3(GoalData goalData)
    {
        int MaxGoal = 10;
        SetGoalInt(goalData, m_gameManager.familyLevel, MaxGoal);

        //Reach 10 pts for family
        if (m_gameManager.familyLevel >= MaxGoal)
        {
            Debug.Log("Goal3 Got");

            return true;
        }
        else { return false; }
    }
    bool Goal4(GoalData goalData)
    {
        int MaxGoal = 10;
        int HighestInsuranceProgress = Mathf.Max(buyInsuranceHealth.insuranceBoughtCountCategory, buyInsuranceAccident.insuranceBoughtCountCategory, buyInsuranceCritical.insuranceBoughtCountCategory, buyInsuranceLife.insuranceBoughtCountCategory);
        SetGoalInt(goalData, HighestInsuranceProgress, MaxGoal);
        

        // Buy the same insurance category for 10 consecutive turns
        bool reachedGoal = buyInsuranceHealth.insuranceBoughtCountCategory >= MaxGoal ||
                   buyInsuranceAccident.insuranceBoughtCountCategory >= MaxGoal ||
                   buyInsuranceCritical.insuranceBoughtCountCategory >= MaxGoal ||
                   buyInsuranceLife.insuranceBoughtCountCategory >= MaxGoal;

        if (reachedGoal && m_gameManager.PhaseInt == 4)
        {
            Debug.Log("Goal4 Got");
            return true;
        }
        else { return false; }

    }
    // BUGGED
    // If user does not buy all insurance, counter will still increase
    bool Goal5(GoalData goalData)
    {
        int MaxGoal = 3;
        int HighestInsuranceProgress = Mathf.Min(buyInsuranceHealth.insuranceBoughtCountCategory, buyInsuranceAccident.insuranceBoughtCountCategory, buyInsuranceCritical.insuranceBoughtCountCategory, buyInsuranceLife.insuranceBoughtCountCategory);
        SetGoalInt(goalData, HighestInsuranceProgress, MaxGoal);

        // Hold all 4 categories of insurance for 3 consecutive turns
        bool reachedGoal = buyInsuranceHealth.insuranceBoughtCountCategory >= MaxGoal &&
                   buyInsuranceAccident.insuranceBoughtCountCategory >= MaxGoal &&
                   buyInsuranceCritical.insuranceBoughtCountCategory >= MaxGoal &&
                   buyInsuranceLife.insuranceBoughtCountCategory >= MaxGoal;

        if (reachedGoal && m_gameManager.PhaseInt == 4)
        {
            Debug.Log("Goal5 Got");
            return true;
        }
        else { return false; }
    }

    // NOT USED
    bool Goal6(GoalData goalData)
    {
        int MaxGoal = 5;
        SetGoalInt(goalData, m_gameManager.increasedHealth, MaxGoal);

        //Restore a total of 5 Health Points
        if (m_gameManager.increasedHealth >= MaxGoal)
        {
            Debug.Log("Goal6 Got");
            return true;
        }
        else { return false; }
    }
    bool Goal7(GoalData goalData)
    {
        // ADJUST MONEY
        int MaxGoal = 50000;
        SetGoalInt(goalData, m_gameManager.spentMoney, MaxGoal);

        //Spend $ on insurance
        if (m_gameManager.spentMoney >= MaxGoal)
        {
            Debug.Log("Goal7 Got");
            return true;
        }
        else { return false; }
    }
    bool Goal8(GoalData goalData)
    {
        int MaxGoal = 5;
        SetGoalInt(goalData, m_gameManager.timesProtected, MaxGoal);

        //Be insured against 5 crises
        if (m_gameManager.timesProtected >= MaxGoal)
        {
            Debug.Log("Goal8 Got");
            return true;
        }
        else { return false; }
    }
    bool Goal9(GoalData goalData)
    {
        int MaxGoal = 5;
        SetGoalInt(goalData, m_dropArea.droppedCardInt, MaxGoal);

        //Play 5 cards in a turn
        if (m_dropArea.droppedCardInt >= MaxGoal)
        {
            Debug.Log("Goal9 Got");
            return true;
        }
        else { return false; }
    }
    bool Goal10(GoalData goalData)
    {
        int MaxGoal = 5;
        SetGoalInt(goalData, m_addPlayerCards.spawnCardCounter, MaxGoal);

        //Draw 5 cards in a turn
        if (m_addPlayerCards.spawnCardCounter >= MaxGoal)
        {
            Debug.Log("Goal10 Got");
            return true;
        }
        else { return false; }
    }

    void SetGoalInt(GoalData goalData, int referenceCurrentGoal, int maxGoalInt)
    {
        goalData.CurrentGoalInt = referenceCurrentGoal;
        goalData.GoalTargetInt = maxGoalInt;

        if (goalData.CurrentGoalInt > goalData.GoalTargetInt)
        {
            goalData.CurrentGoalInt = goalData.GoalTargetInt;
        }
    }
}