using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InfoDisplay : MonoBehaviour, IPointerDownHandler
{

    [SerializeField]
    private CardData cardInfo; 
    EffectDisplay effectDisplay;

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
    GameObject cardInfoDisplayPrefab;
    private void Awake()
    {
        effectDisplay = cardInfoDisplayPrefab.GetComponent<EffectDisplay>();
    }
    private void Start()
    {
        DisplayInfo();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        effectDisplay.CardInfo = CardInfo;
        Debug.Log("Update");
    }
    void DisplayInfo() //name and cost of card
    {
        cardNameText.text = CardInfo.cardName;
        cardCostText.text = CardInfo.cardCost.ToString();
        cardImage.sprite = cardInfo.cardImage;
        cardDescriptionText.text = CardInfo.cardDescription;
    }
}
