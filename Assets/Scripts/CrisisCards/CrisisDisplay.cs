using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrisisDisplay : MonoBehaviour
{
    [SerializeField]
    private CrisisData crisisInfo;
    
    public CrisisData CrisisInfo
    {
        get { return crisisInfo; }
        set { crisisInfo = value; }
    }

    [SerializeField]
    Text cardNameText;
    [SerializeField]
    Text cardDescriptionText;

    [SerializeField]
    static int numberOfCardsInDeck;

    private void Start()
    {
        numberOfCardsInDeck = PlayerDeck.deckSize;
    }

    private void Update()
    {
        DisplayInfo();
        
    }

    void DisplayInfo()
    {
        cardNameText.text = CrisisInfo.cardName;
        cardDescriptionText.text = CrisisInfo.cardDescription;
    }
}
