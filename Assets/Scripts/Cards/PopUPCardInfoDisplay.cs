using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUPCardInfoDisplay : MonoBehaviour
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

    private void Update()
    {
        showCardInfo();
    }
    void showCardInfo() //name and cost of card
    {
        cardNameText.text = CardInfo.cardName;
        cardImage.sprite = cardInfo.cardImage;
        cardImage.enabled = true;
        cardDescriptionText.text = "Personal needs effect : " + cardInfo.personalIncrease + "\n\nJob needs effect : "
                                    + cardInfo.jobIncrease + "\n\nFamily needs effect : " + cardInfo.familyIncrease + "\n\nCost : $" + cardInfo.cardCost;
    }
}
