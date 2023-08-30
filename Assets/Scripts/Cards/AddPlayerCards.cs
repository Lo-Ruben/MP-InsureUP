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

    public int drawCost;

    void Start()
    {
        drawCost = 4;
        m_playerManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        childCount = this.transform.childCount;

        costToDraw.text = "Cost to draw: " + drawCost;
        if (m_playerManager.PhaseInt == 1 && PlayerDeck.deckSize > 0)
        {
            if (childCount >= m_playerManager.MaxPlayerHand)
            {
                Debug.Log("Player's hand is full");
                m_playerManager.PhaseInt += 1;
            }
        }
    }

    // Instantiate a card in PlayerHand
    // It is also attached to a button 
    public void SpawnCard()
    {
        if (this.transform.childCount < m_playerManager.MaxPlayerHand)
        {
            m_playerManager.money -= drawCost;
            GameObject temp = Instantiate(card, transform.position, transform.rotation);
            temp.transform.SetParent(this.transform);
            spawnCardCounter++;
        }
    }
}
