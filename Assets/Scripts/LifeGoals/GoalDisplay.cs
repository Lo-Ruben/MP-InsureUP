using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalDisplay : MonoBehaviour
{
    public Text GoalHeader;
    public Image GoalImage;
    public Text GoalDescription;

    public GoalData goalData;

    private void Update()
    {
        GoalHeader.text = goalData.goalName;
        
        GoalDescription.text = goalData.goalDescription;

        GoalImage.sprite = goalData.goalSprite;
        GoalImage.enabled = true;
    }
}
