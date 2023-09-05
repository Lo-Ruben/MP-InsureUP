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
    bool staticCardBack = false;

    public GameObject cardBack;

    [SerializeField]
    static int numberOfCardsInDeck;

    [SerializeField]
    Text cardNameText;
    [SerializeField]
    Text cardDescriptionText;
    [SerializeField]
    Text cardCostText;
    [SerializeField]
    Image cardImage;

    private void Awake()
    {
        cardNameText.text = null;
        cardDescriptionText.text = null;
        cardCostText.text = null;
        cardImage.enabled = false;
    }

    private void Start()
    {
        StartCoroutine(TextAfterAnimation());
    }

    private void Update()
    {
        numberOfCardsInDeck = ActionDeck.deckSize;

        if (staticCardBack == true)
        {
            cardBack.SetActive(true);
        }
        else
        {
            cardBack.SetActive(false);
        }

        // If card appears in player's hand, reduce ActionDeck
        if (this.tag == "Clone")
        {
            CardInfo = ActionDeck.staticDeck[numberOfCardsInDeck - 1];
            //Debug.Log(numberOfCardsInDeck - 1);

            //DisplayInfo();
            staticCardBack = false;
            this.tag = "Untagged";

            ActionDeck.ReduceDeck();

        }
    }

    void DisplayInfoTop() //name and cost of card
    {
        cardNameText.text = CardInfo.cardName;
        cardCostText.text = CardInfo.cardCost.ToString();
    }
    void DisplayInfoMid() //image of card
    {
        cardImage.sprite = cardInfo.cardImage;
        cardImage.enabled = true;
    }
    void DisplayInfoBot() //description of card
    {
        cardDescriptionText.text = CardInfo.cardDescription;
    }

        IEnumerator TextAfterAnimation()
    {
        yield return new WaitForSeconds(0.1f);
        DisplayInfoTop();
        yield return new WaitForSeconds(0.1f);
        DisplayInfoMid();
        yield return new WaitForSeconds(0.1f);
        DisplayInfoBot();
    }

    public void RefreshInfo()
    {
        StartCoroutine(TextAfterAnimation());
    }
}
