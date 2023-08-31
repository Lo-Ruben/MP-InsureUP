using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToughDecision : MonoBehaviour
{
    // Script to manage decision UI

    public GameObject toughDecisionPanel;

    public AddPlayerCards addPlayerCards;
    public GameManager gameManager;
    public PlayerDeck playerDeck;

    // List of 3 cards for the player to choose
    public List<GameObject> choiceCards = new List<GameObject>();
    public List<CardData> cardList = new List<CardData>();

    // Updates 3 card data from action deck
    // Activates popup UI for choosing cards
    public void ShowDecisionPanelUI()
    {
        //Debug.Log("Starting Decision");//works
        if (playerDeck.deck.Count >= 3)
        {
            toughDecisionPanel.SetActive(true);
            for (int i = 0; i < 3; i++)
            {
                cardList.Add(playerDeck.deck[playerDeck.deck.Count - 1 - i]);
                choiceCards[i].GetComponent<CardDisplay>().CardInfo = cardList[i];
                choiceCards[i].GetComponent<Button>().enabled = true;
                choiceCards[i].GetComponent<CardDisplay>().RefreshInfo();
            }
        }

    }

    // Removes items in list and hides panel
    public void HideDecisionPanelUI()
    {
        cardList.Clear();
        toughDecisionPanel.SetActive(false);
    }

    // Each card within the UI has a button component attached
    // Supposed to be 2 cards in discard and 1 card in player hand
    // But 3 cards in discard and 1 card in player hand
    public void DecideCardButton()
    {
        GameObject decision = EventSystem.current.currentSelectedGameObject;

        // Destroy button component
        foreach (GameObject cards in choiceCards)
        {
            cards.GetComponent<Button>().enabled = false;
        }

        Transform discardTransform = gameManager.discardObj.transform;
        Transform handTransform = gameManager.handObj.transform;

        //draw the chosen card
        GameObject temp = Instantiate(decision, handTransform.position, handTransform.rotation, handTransform);
        addPlayerCards.spawnCardCounter++;

        //discard the unchosen cards
        foreach (GameObject unchosen in choiceCards)
        {
            GameObject discard = Instantiate(unchosen, discardTransform.position, discardTransform.rotation, discardTransform);
            Draggable discardDraggable = discard.GetComponent<Draggable>();
            discardDraggable.isDraggingStop = true;

            CanvasGroup discardCanvasGroup = discard.GetComponent<CanvasGroup>();
            discardCanvasGroup.blocksRaycasts = false;
        }
        
        HideDecisionPanelUI();
    }
}
