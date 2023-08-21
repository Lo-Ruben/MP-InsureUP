using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerGoals : MonoBehaviour
{
    public GameObject[] goalSets = new GameObject[] {};

    
    public GameObject[] goalCards = new GameObject[] {};

    public static GoalData goalDataSaved1;
    public static GoalData goalDataSaved2;
    public static GoalData goalDataSaved3;

    public GameObject nextButton;
    public GameObject previousButton;
    

    [SerializeField]
    private int goalGroup = 1;

    void Start()
    {
        
    }

    private void Update()
    {
        Debug.Log(goalGroup);
        if (goalGroup >= goalSets.Length)
        {
            nextButton.SetActive(false);
        }
        if (goalGroup <= 1)
        {
            previousButton.SetActive(false);
        }
        else if (goalGroup > 1 && goalGroup < goalSets.Length)
        {
            nextButton.SetActive(true);
            previousButton.SetActive(true);
        }
    }

    //SceneManager.LoadScene("TableScene");

    public void SelectGoalGroupButton()
    {
        GameObject goal1 = goalSets[goalGroup - 1].transform.GetChild(0).GetChild(0).gameObject;
        GameObject goal2 = goalSets[goalGroup - 1].transform.GetChild(0).GetChild(1).gameObject;
        GameObject goal3 = goalSets[goalGroup - 1].transform.GetChild(0).GetChild(2).gameObject;

        goalDataSaved1 = goal1.GetComponent<GoalDisplay>().goalData;
        goalDataSaved2 = goal2.GetComponent<GoalDisplay>().goalData;
        goalDataSaved3 = goal3.GetComponent<GoalDisplay>().goalData;
        Debug.Log(goalDataSaved1.goalName + goalDataSaved2.goalName + goalDataSaved3.goalName);
        TestGoalGroup();

        SceneManager.LoadScene("TableScene");
    }

    public void NextGoalGroup()
    {
        goalGroup += 1;
        EnableGoalGroups();
        if (goalGroup == 2)
        {
            goalCards[(goalGroup - 2)].SetActive(false);
        } else if (goalGroup == 3)
        {
            goalCards[(goalGroup - 2)].SetActive(false);
        }

    }
    public void PreviousGoalGroup()
    {
        goalGroup -= 1;
        EnableGoalGroups();
        if (goalGroup == 2)
        {
            goalCards[(goalGroup)].SetActive(false);
        } else if (goalGroup == 1)
        {
            goalCards[(goalGroup)].SetActive(false);
        }

    }

    public void ShowGoals()
    {
        
        goalCards[(goalGroup - 1)].SetActive(true);
    }

    public void Back()
    {
        
        goalCards[(goalGroup - 1)].SetActive(false);
    }

    void EnableGoalGroups()
    {
        if (goalGroup >= 1 && goalGroup <= goalSets.Length)
        {
            for (int i = 0; i < goalSets.Length; i++)
            {
                goalSets[i].SetActive(i + 1 == goalGroup);
            }
        }
    }

    void TestGoalGroup()
    {
        Debug.Log(goalDataSaved1.name + goalDataSaved2.name + goalDataSaved3.name);
    }

}
