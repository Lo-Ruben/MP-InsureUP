using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CardInfoDisplay : MonoBehaviour, IPointerDownHandler
{
    PopUPCardInfoDisplay popUpCardInfoDisplay;
    [SerializeField]
    private CardData cardInfo;

    void Start()
    {
        showCardInfo();
    }
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
    [SerializeField]
    GameObject cardInfoDisplayPrefab;

    private void Awake()
    {
        cardNameText.text = null;
        cardDescriptionText.text = null;
        cardImage.enabled = false;
        popUpCardInfoDisplay = cardInfoDisplayPrefab.GetComponent<PopUPCardInfoDisplay>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(CardInfo.cardName);
        Debug.Log(popUpCardInfoDisplay!= null);
        popUpCardInfoDisplay.CardInfo = CardInfo;
    }

    void showCardInfo() //name and cost of card
    {
        cardNameText.text = CardInfo.cardName;
        cardImage.sprite = CardInfo.cardImage;
        cardImage.enabled = true;
        cardDescriptionText.text = CardInfo.cardDescription;
    }

    
}
