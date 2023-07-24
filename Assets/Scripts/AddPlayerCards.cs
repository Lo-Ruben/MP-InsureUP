using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerCards : MonoBehaviour
{
    // Add player cards adds cards onto the player's hand in the scene
    // Press w to instantiate a card
    // Player's hand limit may change

    public GameObject card;

    [SerializeField]
<<<<<<< Updated upstream
    int maxPlayerHand;
=======
    GameManager m_GameManager;

    [SerializeField]
    CrisisDeck m_crisisDeck;
>>>>>>> Stashed changes

    void Start()
    {
        //StartCoroutine(StartGame());
    }
    void Update()
    {
<<<<<<< Updated upstream
        if (Input.GetKeyDown("w") && PlayerDeck.deckSize > 0)
        {
            if (this.transform.childCount < maxPlayerHand)
=======
        // If draw phase and deck got cards
        if (m_GameManager.PhaseInt == 1 && PlayerDeck.deckSize > 0 )
        {
            // When "W" is pressed
            if (Input.GetKeyDown("w"))
>>>>>>> Stashed changes
            {
                SpawnCard();
            }
            // If player has the max amount of cards held 
            if (this.transform.childCount >= m_GameManager.MaxPlayerHand)
            {
                Debug.Log("Player's hand is full");
<<<<<<< Updated upstream
=======
                m_GameManager.PhaseInt += 1;
>>>>>>> Stashed changes
            }
        }
    }
    IEnumerator StartGame()
    {
        for(int i = 0; i<5; i++)
        {
            yield return new WaitForSeconds(1);

            SpawnCard();
        }
    }

    void SpawnCard()
    {
        GameObject temp = Instantiate(card, transform.position, transform.rotation);
        temp.transform.SetParent(this.transform);
<<<<<<< Updated upstream
=======
        if(m_crisisDeck.crisisDeck.Count > 0)
        {
            m_crisisDeck.disasterCounter -= 1;
        }
>>>>>>> Stashed changes
    }
}
