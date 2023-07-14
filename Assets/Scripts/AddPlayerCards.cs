using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerCards : MonoBehaviour
{
    public GameObject card;

    [SerializeField]
    int maxPlayerHand;

    void Start()
    {
        //StartCoroutine(StartGame());
    }
    void Update()
    {
        if (Input.GetKeyDown("w") && PlayerDeck.deckSize > 0)
        {
            if (this.transform.childCount < maxPlayerHand)
            {
                SpawnCard();
            }
            else
            {
                Debug.Log("Player's hand is full");
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
    }
}
