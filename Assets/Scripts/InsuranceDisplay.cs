using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsuranceDisplay : MonoBehaviour
{

    //public InsuranceData insuranceInfo { get; set; }
    [SerializeField]
    private InsuranceData insuranceInfo;
    
    public InsuranceData InsuranceInfo
    {
        get { return insuranceInfo; }
        set { insuranceInfo = value; }
    }

    [SerializeField]
    Text cardNameText;
    [SerializeField]
    Text cardDescriptionText;
    [SerializeField]
    Text cardCostText;
    [SerializeField]
    Image cardImage;

    [SerializeField]
    bool staticCardBack = false;

    public GameObject cardBack;
    [SerializeField]
    static int numberOfCardsInDeck;

    private void Start()
    {
        numberOfCardsInDeck = PlayerDeck.deckSize;
        DisplayInfo();
    }

    private void Update()
    {

        if (staticCardBack == true)
        {
            cardBack.SetActive(true);
        }
        else
        {
            cardBack.SetActive(false);
        }
    }

    void DisplayInfo()
    {
        cardNameText.text = InsuranceInfo.cardName;
        cardDescriptionText.text = InsuranceInfo.cardDescription;
        cardCostText.text = InsuranceInfo.cardCost.ToString();
        cardImage.sprite = InsuranceInfo.cardImage;
        staticCardBack = false;
    }
}
