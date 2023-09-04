using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InfoDisplay : MonoBehaviour, IPointerDownHandler
{
    // InfoDisplay is used for the Info prefab & helps to update text and image based on the referenced scriptable object [CardData]
    // Info Prefab is the base layout of the card 


    [SerializeField]
    private CardData cardData; 
    EffectDisplay effectDisplay;

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
    public AudioSource audioSource;
    public AudioClip click;
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
        audioSource.clip = click;
        audioSource.Play();
        effectDisplay.CardInfo = cardData;
    }
    void DisplayInfo() //name and cost of card
    {
        cardNameText.text = cardData.cardName;
        cardCostText.text = cardData.cardCost.ToString();
        cardImage.sprite = cardData.cardImage;
        cardDescriptionText.text = cardData.cardDescription;
    }
}
