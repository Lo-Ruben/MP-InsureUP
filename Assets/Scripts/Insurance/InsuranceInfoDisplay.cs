using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsuranceInfoDisplay : MonoBehaviour
{
    [SerializeField]
    private InsuranceInfo insruanceInfo;

    public InsuranceInfo insuranceInfo
    {
        get { return insruanceInfo; }
        set { insruanceInfo = value; }
    }

    [SerializeField]
    Text cardNameText;
    [SerializeField]
    Text cardDescriptionText;
    [SerializeField]
    Image cardImage;

    //private void Start()
    //{
    //    DisplayInfo();
    //}

    private void Update()
    {
        DisplayInfo();
    }


    void DisplayInfo()
    {
        cardNameText.text = insuranceInfo.cardName;
        cardDescriptionText.text = insuranceInfo.cardCounter;
        cardImage.sprite = insuranceInfo.cardImage;
    }
}
