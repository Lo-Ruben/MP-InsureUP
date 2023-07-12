using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<CardData> deck = new List<CardData>();
    public List<CardData> existingCards = new List<CardData>();
    public List<CardData> container = new List<CardData>();
    public int deckSize;
    int randomInt;
    int cardTypeAmount = 10;

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    void Start()
    {
        randomInt = 0;
        for (int i = 0; i < cardTypeAmount; i++)
        {
            for(int x =0; x< existingCards.Count; x++)
            {
                deck.Add(existingCards[x]);
            }
            
        }
    }
    void Update()
    {
        deckSize = deck.Count;
        if(deckSize)
    }

    // Fisher-Yates Shuffle Algorithm
    // https://www.youtube.com/watch?v=V8vGlC2ZB_g
    public void Shuffle()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int r = (int)(Random.value * (deck.Count - i));
            Debug.Log(i+":"+r);
            //Debug.Log(deck.Count - i);
            CardData temp = deck[r];
            deck[r] = deck[i];
            deck[i] = temp;
        }
         //CountOccurrences(existingCards[2]);
    }

    public int CountOccurrences(CardData item)
    {
        List<CardData> occurrences = deck.FindAll(i => i == item);
        Debug.Log(occurrences.Count);
        return occurrences.Count;
    }
}
