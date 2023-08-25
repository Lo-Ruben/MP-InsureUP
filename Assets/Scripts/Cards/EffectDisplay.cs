using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EffectDisplay : MonoBehaviour
{
    // EffectDisplay helps to display information for cards by referencing the scriptable object on mouse click
    // Effect Info prefab is used for the card info pannel within the UI

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

    private void Update()
    {
        DisplayInfo();
    }
    void DisplayInfo() //name and cost of card
    {
        cardNameText.text = CardInfo.cardName;
        cardImage.sprite = cardInfo.cardImage;
        cardDescriptionText.text = "Personal Needs : " + cardInfo.personalIncrease + "\n\nJob Needs : " + cardInfo.jobIncrease +
                                   "\n\nFamily Needs : " + cardInfo.familyIncrease + "\n\nCost : $" + cardInfo.cardCost;
    }
}
