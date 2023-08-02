using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField]
    private CardData cardInfo;
    
    public CardData CardInfo
    {
        get { return cardInfo; }
        set { cardInfo = value; }
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
    private void Awake()
    {
        cardNameText.text = null;
        cardDescriptionText.text = null;
        cardCostText.text = null;
        cardImage.sprite = null;
    }

    private void Start()
    {
        numberOfCardsInDeck = PlayerDeck.deckSize;
        StartCoroutine(TextAfterAnimation());
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
            CardInfo = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            //Debug.Log(numberOfCardsInDeck - 1);

            //DisplayInfo();
            staticCardBack = false;
            this.tag = "Untagged";

            PlayerDeck.ReduceDeck();

        }
    }

    void DisplayInfo()
    {
        cardNameText.text = CardInfo.cardName;
        cardDescriptionText.text = CardInfo.cardDescription;
        cardCostText.text = CardInfo.cardCost.ToString();
        cardImage.sprite = cardInfo.cardImage;
    }

        IEnumerator TextAfterAnimation()
    {
        yield return new WaitForSeconds(0.2f);
        DisplayInfo();
    }
}
