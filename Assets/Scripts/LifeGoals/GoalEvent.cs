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
        string goalName = PlayerGoals.goalDataSaved1.name;

        if (CheckGoal(goalName))
        {
            UnsubscribeGoalCheck1();
        }
    }

    private void GoalCheck2_Conditions(object sender, System.EventArgs e)
    {
        string goalName = PlayerGoals.goalDataSaved2.name;

        if (CheckGoal(goalName))
        {
            UnsubscribeGoalCheck2();
        }
    }

    private void GoalCheck3_Conditions(object sender, System.EventArgs e)
    {
        string goalName = PlayerGoals.goalDataSaved3.name;

        if (CheckGoal(goalName))
        {
            UnsubscribeGoalCheck3();
        }
    }

    private bool CheckGoal(string goalName)
    {
        switch (goalName)
        {
            case "Goal1": return Goal1();
            case "Goal2": return Goal2();
            case "Goal3": return Goal3();
            case "Goal4": return Goal4();
            case "Goal5": return Goal5();
            case "Goal6": return Goal6();
            case "Goal7": return Goal7();
            case "Goal8": return Goal8();
            case "Goal9": return Goal9();
            case "Goal10": return Goal10();
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
    bool Goal1()
    {
        //Reach 10 pts for work
        if (m_gameManager.jobLevel >= 10)
        {
            Debug.Log("Goal1 Got");

            return true;
        }
        else { return false; }
    }
    bool Goal2()
    {
        //Reach 10 pts for personal
        if (m_gameManager.personalLevel >= 10)
        {
            Debug.Log("Goal2 Got");

            return true;
        }
        else { return false; }
    }
    bool Goal3()
    {
        //Reach 10 pts for family
        if (m_gameManager.familyLevel >= 10)
        {
            Debug.Log("Goal3 Got");

            return true;
        }
        else { return false; }
    }
    bool Goal4()
    {
        // Checks if player has bought the same insurance type for 10 rounds straight
        bool reachedGoal = buyInsuranceHealth.continuousInsuranceTurnInt >= 10 ||
                   buyInsuranceAccident.continuousInsuranceTurnInt >= 10 ||
                   buyInsuranceCritical.continuousInsuranceTurnInt >= 10 ||
                   buyInsuranceLife.continuousInsuranceTurnInt >= 10;

        if (reachedGoal && m_gameManager.PhaseInt == 5)
        {
            Debug.Log("Goal4 Got");
            return true;
        }
        else { return false; }

    }
    bool Goal5()
    {
        // Hold every type of insurance card possible for 3 consecutive turns
        bool reachedGoal = buyInsuranceHealth.continuousInsuranceTurnInt >= 3 &&
                   buyInsuranceAccident.continuousInsuranceTurnInt >= 3 &&
                   buyInsuranceCritical.continuousInsuranceTurnInt >= 3 &&
                   buyInsuranceLife.continuousInsuranceTurnInt >= 3;
        if (reachedGoal && m_gameManager.PhaseInt == 5)
        {
            Debug.Log("Goal5 Got");
            return true;
        }
        else { return false; }
    }

    bool Goal6()
    {
        //Restore a total of 5 Health Points
        if (m_gameManager.increasedHealth >= 5)
        {
            Debug.Log("Goal6 Got");
            return true;
        }
        else { return false; }
    }
    bool Goal7()
    {
        //Spend $ on insurance
        if (m_gameManager.spentMoney >= 50)
        {
            Debug.Log("Goal7 Got");
            return true;
        }
        else { return false; }
    }
    bool Goal8()
    {
        //Be insured against 5 crises
        if (m_gameManager.timesProtected >= 5)
        {
            Debug.Log("Goal8 Got");
            return true;
        }
        else { return false; }
    }
    bool Goal9()
    {
        //Play 5 cards in a turn
        if (m_dropArea.droppedCardInt >= 5)
        {
            Debug.Log("Goal9 Got");
            return true;
        }
        else { return false; }
    }
    bool Goal10()
    {
        //Draw 5 cards in a turn
        if (m_addPlayerCards.spawnCardCounter >= 5)
        {
            Debug.Log("Goal10 Got");
            return true;
        }
        else { return false; }
    }
}