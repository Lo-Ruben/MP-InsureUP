using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerCards : MonoBehaviour
{
    public GameObject card;
    void Start()
    {
        StartCoroutine(StartGame());
    }
    void Update()
    {
        if (Input.GetKeyDown("w") && PlayerDeck.deckSize > 0)
        {
            GameObject temp = Instantiate(card, transform.position, transform.rotation);
            temp.transform.SetParent(this.transform);
        }
    }
    IEnumerator StartGame()
    {
        for(int i = 0; i<5; i++)
        {

            yield return new WaitForSeconds(1);

            GameObject temp = Instantiate(card, transform.position, transform.rotation);
            temp.transform.SetParent(this.transform);
        }
    }
}
