using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPlayerCards : MonoBehaviour
{
    // Add player cards adds cards onto the player's hand in the scene
    // Press w to instantiate a card
    // Player's hand limit may change

    public CardData cardData;

    
    public Text costToDraw;

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
        //Debug.Log(cardData.drawDiscount);
        if (cardData.drawDiscount == true)
        {
            costToDraw.text = "Cost to draw: " + 3;

        }
        else if (cardData.drawDiscount == false)
        {
            costToDraw.text = "Cost to draw: " + 4;

        }

        if (m_playerManager.PhaseInt == 1 && PlayerDeck.deckSize > 0)
        {
            if (this.transform.childCount >= m_playerManager.MaxPlayerHand)
            {
                Debug.Log("Player's hand is full");
                m_playerManager.PhaseInt += 1;
            }
            else if (Input.GetKeyDown(KeyCode.W) && this.transform.childCount < m_playerManager.MaxPlayerHand)
            {
                SpawnCard();
                //Debug.Log(m_crisisDeck.disasterCounter);
            }
        }
    }

    // Instantiate a card in PlayerHand
    void SpawnCard()
    {
        if(cardData.drawDiscount == true)
        {
            m_playerManager.money -= 3;

        }
        else if (cardData.drawDiscount == false)
        {
            m_playerManager.money -= 4;
            
        }
        
        GameObject temp = Instantiate(card, transform.position, transform.rotation);
        temp.transform.SetParent(this.transform);
        spawnCardCounter++;
    }
}
