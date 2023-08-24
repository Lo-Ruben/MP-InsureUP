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
            for (int i = 0; i < 3; i++)
            {
                cardList.Add(playerDeck.deck[playerDeck.deck.Count - 1 - i]);
                //Debug.Log(cardList[i].cardName);
            }
            toughDecisionPanel.SetActive(true);
            for (int i = 0; i < 3; i++)
            {
                choiceCards[i].GetComponent<CardDisplay>().CardInfo = cardList[i];
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
        //Debug.Log("Decided!" + decision.name);

        // Destroy button component
        foreach (GameObject cards in choiceCards)
        {
            Destroy(cards.GetComponent<Button>());
        }
        //discard the unchosen cards
        foreach (GameObject unchosen in choiceCards)
        {
            GameObject discard = Instantiate(unchosen, gameManager.discardObj.transform.position, gameManager.discardObj.transform.rotation);
            discard.transform.SetParent(gameManager.discardObj.transform);
            discard.GetComponent<Draggable>().isDraggingStop = true;
            discard.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        //draw the chosen card
        GameObject temp = Instantiate(decision, gameManager.handObj.transform.position, gameManager.handObj.transform.rotation);
        temp.transform.SetParent(gameManager.handObj.transform);
        addPlayerCards.spawnCardCounter++;
        choiceCards.Remove(decision);
        HideDecisionPanelUI();
    }
}
