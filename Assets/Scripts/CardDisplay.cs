using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public CardData cardInfo { get; set; }

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
            //Debug.Log(numberOfCardsInDeck - 1);

            cardNameText.text = cardInfo.cardName;
            cardDescriptionText.text = cardInfo.cardDescription;
            cardCostText.text = cardInfo.cardCost.ToString();
            cardImage.sprite = cardInfo.cardImage;

            staticCardBack = false;
            this.tag = "Untagged";

            PlayerDeck.ReduceDeck();

        }
    }
}
