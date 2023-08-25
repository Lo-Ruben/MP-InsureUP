using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EffectDisplay : MonoBehaviour
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
    Image cardImage;

    private void Start()
    {
        DisplayInfo();
    }
    void DisplayInfo() //name and cost of card
    {
        cardNameText.text = CardInfo.cardName;
        cardImage.sprite = cardInfo.cardImage;
        cardDescriptionText.text = "Personal Needs : " + cardInfo.personalIncrease + "\n\n Job Needs : " + cardInfo.jobIncrease +
                                   "\n\n Family Needs : " + cardInfo.familyIncrease + "\n\n Cost : $" + cardInfo.cardCost;
    }
}
