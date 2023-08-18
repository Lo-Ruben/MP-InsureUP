using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrisisDisplay : MonoBehaviour
{
    [SerializeField]
    private CrisisData crisisInfo;
    [SerializeField]
    private Animator animator;
    
    public CrisisData CrisisInfo
    {
        get { return crisisInfo; }
        set { crisisInfo = value; }
    }

    [SerializeField]
    Text cardNameText;
    [SerializeField]
    Text cardDescriptionText;

    private void Update()
    {
        DisplayInfo();
        
    }

    void DisplayInfo()
    {
        if (crisisInfo != null)
        {
            cardNameText.text = CrisisInfo.cardName;
            cardDescriptionText.text = CrisisInfo.cardDescription;
            animator.runtimeAnimatorController = crisisInfo.animatorController;
        }
    }
}
