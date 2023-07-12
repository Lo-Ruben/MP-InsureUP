using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField]
    private CardData card;

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

    private void Start()
    {
        cardNameText.text = card.cardName;
        cardDescriptionText.text = card.cardDescription;
        cardCostText.text = card.cardCost.ToString();
        cardImage.sprite = card.cardImage;
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
}
