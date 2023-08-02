using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsuranceDisplay : MonoBehaviour
{
    [SerializeField]
    private InsuranceData insuranceData;
    
    public InsuranceData InsuranceData
    {
        get { return insuranceData; }
        set { insuranceData = value; }
    }

    [SerializeField]
    Text cardNameText;
    [SerializeField]
    Text cardDescriptionText;
    [SerializeField]
    Text cardCostText;

    public bool staticCardBack = false;

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
        cardNameText.text = InsuranceData.cardName;
        cardDescriptionText.text = InsuranceData.cardDescription;
        cardCostText.text = InsuranceData.cardCost.ToString();
        staticCardBack = false;
    }
}
