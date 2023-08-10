using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEvent : MonoBehaviour
{
    [SerializeField]
    GameManager m_gameManager;

    EventUpdate m_eventUpdate;

    private void Start()
    {
        m_eventUpdate = GetComponent<EventUpdate>();
        m_eventUpdate.CheckGoals += GoalCheck1_Conditions;
        m_eventUpdate.CheckGoals += GoalCheck2_Conditions;
        m_eventUpdate.CheckGoals += GoalCheck3_Conditions;
    }

    private void GoalCheck1_Conditions(object sender, System.EventArgs e)
    {
        switch (PlayerGoals.goalDataSaved1.name)
        {
            case "Goal1":
                if(Goal1()== true)
                {
                    UnsubscribeGoalCheck1();
                }
                break;
            case "Goal2":
                if (Goal2() == true)
                {
                    UnsubscribeGoalCheck1();
                }
                break;
            case "Goal3":
                if (Goal3() == true)
                {
                    UnsubscribeGoalCheck1();
                }
                break;
            case "Goal4":
                if (Goal4() == true)
                {
                    UnsubscribeGoalCheck1();
                }
                break;
            case "Goal5":
                if (Goal5() == true)
                {
                    UnsubscribeGoalCheck1();
                }
                break;
            case "Goal6":
                if (Goal6() == true)
                {
                    UnsubscribeGoalCheck1();
                }
                break;
            case "Goal7":
                if (Goal7() == true)
                {
                    UnsubscribeGoalCheck1();
                }
                break;
            case "Goal8":
                if (Goal8() == true)
                {
                    UnsubscribeGoalCheck1();
                }
                break;
            case "Goal9":
                if (Goal9() == true)
                {
                    UnsubscribeGoalCheck1();
                }
                break;
            case "Goal10":
                if (Goal10() == true)
                {
                    UnsubscribeGoalCheck1();
                }
                break;
        } 
    }
    private void GoalCheck2_Conditions(object sender, System.EventArgs e)
    {
        switch (PlayerGoals.goalDataSaved2.name)
        {
            case "Goal1":
                if (Goal1() == true)
                {
                    UnsubscribeGoalCheck2();
                }
                break;
            case "Goal2":
                if (Goal2() == true)
                {
                    UnsubscribeGoalCheck2();
                }
                break;
            case "Goal3":
                if (Goal3() == true)
                {
                    UnsubscribeGoalCheck2();
                }
                break;
            case "Goal4":
                if (Goal4() == true)
                {
                    UnsubscribeGoalCheck2();
                }
                break;
            case "Goal5":
                if (Goal5() == true)
                {
                    UnsubscribeGoalCheck2();
                }
                break;
            case "Goal6":
                if (Goal6() == true)
                {
                    UnsubscribeGoalCheck2();
                }
                break;
            case "Goal7":
                if (Goal7() == true)
                {
                    UnsubscribeGoalCheck2();
                }
                break;
            case "Goal8":
                if (Goal8() == true)
                {
                    UnsubscribeGoalCheck2();
                }
                break;
            case "Goal9":
                if (Goal9() == true)
                {
                    UnsubscribeGoalCheck2();
                }
                break;
            case "Goal10":
                if (Goal10() == true)
                {
                    UnsubscribeGoalCheck2();
                }
                break;
        } 
    }
    private void GoalCheck3_Conditions(object sender, System.EventArgs e)
    {

        switch (PlayerGoals.goalDataSaved3.name)
        {
            case "Goal1":
                if (Goal1() == true)
                {
                    UnsubscribeGoalCheck3();
                }
                break;
            case "Goal2":
                if (Goal2() == true)
                {
                    UnsubscribeGoalCheck3();
                }
                break;
            case "Goal3":
                if (Goal3() == true)
                {
                    UnsubscribeGoalCheck3();
                }
                break;
            case "Goal4":
                if (Goal4() == true)
                {
                    UnsubscribeGoalCheck3();
                }
                break;
            case "Goal5":
                if (Goal5() == true)
                {
                    UnsubscribeGoalCheck3();
                }
                break;
            case "Goal6":
                if (Goal6() == true)
                {
                    UnsubscribeGoalCheck3();
                }
                break;
            case "Goal7":
                if (Goal7() == true)
                {
                    UnsubscribeGoalCheck3();
                }
                break;
            case "Goal8":
                if (Goal8() == true)
                {
                    UnsubscribeGoalCheck3();
                }
                break;
            case "Goal9":
                if (Goal9() == true)
                {
                    UnsubscribeGoalCheck3();
                }
                break;
            case "Goal10":
                if (Goal10() == true)
                {
                    UnsubscribeGoalCheck3();
                }
                break;
        }
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
        //Hold onto an insurance card for 10 consecutive turns
        //if()
        //{

        //return true;
        //}
        //else { return false; }
        Debug.Log("Goal4 Got");
        return true;
         
    }
    bool Goal5()
    {
        //Hold every type of insurance card possible for 3 consecutive turns
        //if()
        //{

        //return true;
        //}
        //else { return false; }
        Debug.Log("Goal5 Got");
        return true;
         
    }
    bool Goal6()
    {
        //Restore a total of 5 Health Points
        //if()
        //{

        //return true;
        //}
        //else { return false; }
        Debug.Log("Goal6 Got");
        return true;
         
    }
    bool Goal7()
    {
        //Spend $50k on insurance
        //if()
        //{

        //return true;
        //}
        //else { return false; }
        Debug.Log("Goal7 Got");
        return true;
         
    }
    bool Goal8()
    {
        //Be insured against 5 crises
        //if()
        //{

        //return true;
        //}
        //else { return false; }
        Debug.Log("Goal8 Got");
        return true;
         
    }
    bool Goal9()
    {
        //Play 5 cards in a turn
        //if()
        //{

        //return true;
        //}
        //else { return false; }
        Debug.Log("Goal9 Got");
        return true;


    }
    bool Goal10()
    {
        //Draw 5 cards in a turn
        //if()
        //{

        //return true;
        //}
        //else { return false; }
        Debug.Log("Goal10 Got");
        return true;
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


}
