using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPlayerCards : MonoBehaviour
{
    // Add player cards adds cards onto the player's hand in the scene
    // Press w to instantiate a card
    // Player's hand limit may change
    public Text costToDraw;
    [Header("Insert Card Prefab Here")]
    public GameObject card;

    [Header("Insert GameManagers Here")]
    [SerializeField]
    GameManager m_playerManager;

    [SerializeField]
    CrisisDeck m_crisisDeck;

    public int spawnCardCounter;

    public int childCount;

    void Start()
    {
        m_playerManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        childCount = this.transform.childCount;
        costToDraw.text = "Cost to draw: " + 5;

        // If draw phase and deck got cards and "W" is pressed
        if (m_playerManager.PhaseInt == 1 && PlayerDeck.deckSize > 0 && Input.GetKeyDown("w"))
        {
            // If there are less decks in the 
            if (childCount < m_playerManager.maxCardsHeld)
            {
                SpawnCard();
                //Debug.Log(m_crisisDeck.disasterCounter);
            }
            else
            {
                Debug.Log("Player's hand is full");
                m_playerManager.PhaseInt += 1;
            }
        }
    }

    // Instantiate a card in PlayerHand
    public void SpawnCard()
    {
        m_playerManager.money -= 5;
        GameObject temp = Instantiate(card, transform.position, transform.rotation);
        temp.transform.SetParent(this.transform);
        spawnCardCounter++;
    }
}
