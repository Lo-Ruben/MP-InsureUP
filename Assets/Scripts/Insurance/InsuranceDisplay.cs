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
    [SerializeField]
    Image cardImage;

    public bool staticCardBack = false;

    public GameObject cardBack;
    [SerializeField]
    //static int numberOfCardsInDeck;

    private void Start()
    {
        //numberOfCardsInDeck = ActionDeck.deckSize;
        staticCardBack = false;
        DisplayInfo();
    }

    private void OnEnable()
    {
    }

    private void Update()
    {
        DisplayInfo();
        if (staticCardBack == true)
        {
            cardBack.SetActive(true);
        }
        else
        {
            cardBack.SetActive(false);
        }
    }

    public void DisplayInfo()
    {
        cardNameText.text = InsuranceData.cardName;
        cardDescriptionText.text = InsuranceData.cardDescription;
        cardCostText.text = InsuranceData.cardCost.ToString();
        cardImage.sprite = InsuranceData.cardImage;
    }
}
