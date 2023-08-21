using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GoalData", menuName = "ScriptableObjects/GoalData")]
public class GoalData : ScriptableObject
{
    // Text Info
    public string goalName;
    public Sprite goalSprite;
    public string goalDescription;

    public int GoalTargetInt;
    public int CurrentGoalInt = 0;
}
