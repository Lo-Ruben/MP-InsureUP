using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrisisDisplay : MonoBehaviour
{

    //public InsuranceData insuranceInfo { get; set; }
    [SerializeField]
    private CrisisData crisisInfo;
    
    public CrisisData CrisisInfo
    {
        get { return crisisInfo; }
        set { crisisInfo = value; }
    }

    [SerializeField]
    Text cardNameText;
    [SerializeField]
    Text cardDescriptionText;
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
        cardNameText.text = CrisisInfo.cardName;
        cardDescriptionText.text = CrisisInfo.cardDescription;
        cardImage.sprite = CrisisInfo.cardImage;
        staticCardBack = false;
    }
}
