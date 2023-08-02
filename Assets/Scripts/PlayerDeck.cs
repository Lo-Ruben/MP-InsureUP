using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    // Script is attached to PlayerDeckManager
    // Script handles the generation of card data and order
    // Has a shuffle feature and shows the size of the deck w the 4 GameObjects
    public List<CardData> deck = new List<CardData>();
    public static List<CardData> staticDeck = new List<CardData>();
    public List<CardData> existingCards = new List<CardData>();
    public static int deckSize;
    int cardTypeAmount = 10;

    [Header("Display Deck size for player")]
    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    void Start()
    {
        for (int i = 0; i < cardTypeAmount; i++)
        {
            for(int x =0; x< existingCards.Count; x++)
            {
                deck.Add(existingCards[x]);
            }
            
        }
        deckSize = deck.Count;
        Shuffle();

        staticDeck = deck;
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            CountOccurrences(existingCards[0]);
        }
        if (deckSize <= 75)
        {
            cardInDeck4.SetActive(false);
        }
        if (deckSize <= 50)
        {
            cardInDeck3.SetActive(false);
        }
        if (deckSize <= 25)
        {
            cardInDeck2.SetActive(false);
        }
        if (deckSize <= 0)
        {
            cardInDeck1.SetActive(false);
        }
    }

    // Fisher-Yates Shuffle Algorithm
    // https://www.youtube.com/watch?v=V8vGlC2ZB_g
    public void Shuffle()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int r = (int)(Random.value * (deck.Count - i));
            //Debug.Log(i+":"+r);
            //Debug.Log(deck.Count - i);
            CardData temp = deck[r];
            deck[r] = deck[i];
            deck[i] = temp;
        }
    }

    // Check if all cards are there
    public int CountOccurrences(CardData item)
    {
        List<CardData> occurrences = deck.FindAll(i => i == item);
        Debug.Log(occurrences.Count);
        return occurrences.Count;
    }

    public static void ReduceDeck()
    {
        staticDeck.RemoveAt(staticDeck.Count - 1);
        deckSize -= 1;

        //Debug.Log(deckSize);

    }
}
