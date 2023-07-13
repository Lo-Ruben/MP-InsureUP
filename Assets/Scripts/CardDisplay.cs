using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public List<CardData> displayCard = new List<CardData>();
    [SerializeField]
    private CardData cardInfo;

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

        // If card appears in player's hand, reduce PlayerDeck
        if (this.tag == "Clone")
        {
            cardInfo = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];

            cardNameText.text = cardInfo.cardName;
            cardDescriptionText.text = cardInfo.cardDescription;
            cardCostText.text = cardInfo.cardCost.ToString();
            cardImage.sprite = cardInfo.cardImage;

            //numberOfCardsInDeck -= 1;
            //PlayerDeck.deckSize -= 1;

            PlayerDeck.ReduceDeck();

            staticCardBack = false;
            this.tag = "Untagged";
        }
    }
}
