using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPlayerCards : MonoBehaviour
{
    // Add player cards adds cards onto the player's hand in the scene

    public Text costToDraw;

    [Header("Insert Card Prefab Here")]
    public GameObject card;

    [Header("Insert GameManagers Here")]
    [SerializeField]
    GameManager m_GameManager;

    public int spawnCardCounter;

    public int childCount;

    public int drawCost;

    public AudioClip drawSound;
    public AudioSource audioSource;

    void Start()
    {
        drawCost = 4;
        m_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        childCount = this.transform.childCount;
        costToDraw.text = "Cost to draw: " + drawCost;
        if (m_GameManager.PhaseInt == 1 && ActionDeck.deckSize > 0)
        {
            if (childCount >= m_GameManager.MaxPlayerHand)
            {
                Debug.Log("Player's hand is full");
                m_GameManager.PhaseInt += 1;
            }
        }
    }

    // Instantiate a card in PlayerHand
    public void SpawnCard()
    {
        if (childCount < m_GameManager.MaxPlayerHand)
        {
                m_GameManager.money -= drawCost;
                GameObject temp = Instantiate(card, transform.position, transform.rotation);
                temp.transform.SetParent(this.transform);
                spawnCardCounter++;

                audioSource.clip = drawSound;
                audioSource.Play();
        }
    }

    public void SpawnCardButton()
    {
        if (m_GameManager.PhaseInt == 1)
        {
            m_GameManager.money -= drawCost;
            GameObject temp = Instantiate(card, transform.position, transform.rotation);
            temp.transform.SetParent(this.transform);
            spawnCardCounter++;

            audioSource.clip = drawSound;
            audioSource.Play();
        }
    }
}
