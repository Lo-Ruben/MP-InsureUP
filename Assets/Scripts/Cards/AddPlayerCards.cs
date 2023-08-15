using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerCards : MonoBehaviour
{
    // Add player cards adds cards onto the player's hand in the scene
    // Press w to instantiate a card
    // Player's hand limit may change

    [Header("Insert Card Prefab Here")]
    public GameObject card;

    [Header("Insert GameManagers Here")]
    [SerializeField]
    GameManager m_playerManager;

    [SerializeField]
    CrisisDeck m_crisisDeck;

    public int spawnCardCounter;

    void Start()
    {
        m_playerManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        // If draw phase and deck got cards and "W" is pressed
        if (m_playerManager.PhaseInt == 1 && PlayerDeck.deckSize > 0 && Input.GetKeyDown("w"))
        {
            // If there are less decks in the 
            if (this.transform.childCount < m_playerManager.MaxPlayerHand)
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
    void SpawnCard()
    {
        m_playerManager.money -= 1;
        GameObject temp = Instantiate(card, transform.position, transform.rotation);
        temp.transform.SetParent(this.transform);
        m_crisisDeck.disasterCounter -= 1;
        spawnCardCounter++;
    }
}
