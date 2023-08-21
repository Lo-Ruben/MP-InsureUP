using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerGoalsOld : MonoBehaviour
{
    // Script is attached to
    // Script handles the generation of goals that will be transfered to GameManager
    public List<GoalData> deck = new List<GoalData>();
    public static List<GoalData> staticDeck = new List<GoalData>();

    public GameObject GoalTemplate1;
    public GameObject GoalTemplate2;
    public GameObject GoalTemplate3;

    static GoalDisplay goalDisplay1;
    static GoalDisplay goalDisplay2;
    static GoalDisplay goalDisplay3;

    public static GoalData goalDataSaved1;
    public static GoalData goalDataSaved2;
    public static GoalData goalDataSaved3;

    [SerializeField]
    private int goalCount = 1;

    void Start()
    {
        // Reference static cards
        goalDisplay1 = GoalTemplate1.GetComponent<GoalDisplay>();
        goalDisplay2 = GoalTemplate2.GetComponent<GoalDisplay>();
        goalDisplay3 = GoalTemplate3.GetComponent<GoalDisplay>();

        // Randomize cards
        Shuffle();
        staticDeck = deck;

        // Displays cards at start
        goalDisplay1.goalData = staticDeck[0];
        goalDisplay2.goalData = staticDeck[1];
        goalDisplay3.goalData = staticDeck[2];
    }
    void Update()
    {
        if (staticDeck.Count < 3)
        {
            SceneManager.LoadScene("TableScene");
        }
    }

    // Fisher-Yates Shuffle Algorithm
    // https://www.youtube.com/watch?v=V8vGlC2ZB_g
    public void Shuffle()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int r = (int)(Random.value * (deck.Count - i));
            //Debug.Log(i+":"+r);
            //Debug.Log(deck.Count - i);
            GoalData temp = deck[r];
            deck[r] = deck[i];
            deck[i] = temp;
        }
    }

    // Once button is pressed, read GoalData displayed
    // Save GoalData in static data

    public void Button1()
    {
        switch (goalCount)
        {
            case 1:
                goalDataSaved1 = goalDisplay1.goalData;
                break;
            case 2:
                goalDataSaved2 = goalDisplay1.goalData;
                break;
            case 3:
                goalDataSaved3 = goalDisplay1.goalData;
                break;
            default:
                break;

        }

        goalCount += 1;
        ReduceDeck();
        //TestSavedData();
    }

    public void Button2()
    {
        switch (goalCount)
        {
            case 1:
                goalDataSaved1 = goalDisplay2.goalData;
                break;
            case 2:
                goalDataSaved2 = goalDisplay2.goalData;
                break;
            case 3:
                goalDataSaved3 = goalDisplay2.goalData;
                break;
            default:
                break;

        }

        goalCount += 1;
        ReduceDeck();
        //TestSavedData();
    }

    public void Button3()
    {
        switch (goalCount)
        {
            case 1:
                goalDataSaved1 = goalDisplay3.goalData;
                break;
            case 2:
                goalDataSaved2 = goalDisplay3.goalData;
                break;
            case 3:
                goalDataSaved3 = goalDisplay3.goalData;
                break;
            default:
                break;

        }

        goalCount += 1;
        ReduceDeck();
        TestSavedData();
    }

    void TestSavedData()
    {
        if(goalDataSaved1 != null && goalDataSaved2 && goalDataSaved3 != null)
        {
            Debug.Log(goalDataSaved1.name + goalDataSaved2.name + goalDataSaved3.name);
        }
        else if (goalDataSaved1 != null && goalDataSaved2 != null)
        {
            Debug.Log(goalDataSaved1.name + goalDataSaved2.name);
        }
        else if (goalDataSaved1 != null)
        {
            Debug.Log(goalDataSaved1.name);
        }


        
    }

    public static void ReduceDeck()
    {
        if (staticDeck.Count >= 3)
        {
            staticDeck.RemoveRange(0, 3);

            if (goalDisplay1 != null && staticDeck.Count >= 1)
                goalDisplay1.goalData = staticDeck[0];

            if (goalDisplay2 != null && staticDeck.Count >= 2)
                goalDisplay2.goalData = staticDeck[1];

            if (goalDisplay3 != null && staticDeck.Count >= 3)
                goalDisplay3.goalData = staticDeck[2];
        }
        
    }
}
