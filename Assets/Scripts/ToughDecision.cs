using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToughDecision : MonoBehaviour
{
    //need access to the 3 cards
    public List<GameObject> choiceCards = new List<GameObject>();
    public GameObject toughDecisionPanel;
    // need access to deck
    public PlayerDeck playerDeck;
    // need access to gamemanager
    public GameManager gameManager;

    public List<CardData> cardList = new List<CardData>();
    public AddPlayerCards addPlayerCards;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerDeck = GameObject.Find("ActionDeckManager").GetComponent<PlayerDeck>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDeciding()
    {
        Debug.Log("Starting Decision");//works
        for (int i = 0; i < 3; i++)
        {
            cardList.Add(playerDeck.deck[playerDeck.deck.Count - 1 - i]);
            Debug.Log(cardList[i].cardName);
        }
        toughDecisionPanel.SetActive(true);
        for(int i = 0; i < 3; i++)
        {
            choiceCards[i].GetComponent<CardDisplay>().CardInfo = cardList[i];
        }
    }

    public void StopDeciding()
    {
        cardList.Clear();
        toughDecisionPanel.SetActive(false);
    }

    public void Decide()
    {
        GameObject decision = EventSystem.current.currentSelectedGameObject;
        Debug.Log("Decided!" + decision.name);
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
        }
        //draw the chosen card
        GameObject temp = Instantiate(decision, gameManager.handObj.transform.position, gameManager.handObj.transform.rotation);
        temp.transform.SetParent(gameManager.handObj.transform);
        addPlayerCards.spawnCardCounter++;
        choiceCards.Remove(decision);
        StopDeciding();
    }
}
