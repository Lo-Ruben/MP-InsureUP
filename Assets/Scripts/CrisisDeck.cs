using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrisisDeck : MonoBehaviour
{
    public List<CardData> crisisDeck = new List<CardData>();
    public static List<CardData> staticDeck = new List<CardData>();
    public List<CardData> existingCards = new List<CardData>();
    public static int deckSize;
    int randomInt;
    int cardTypeAmount = 10;

    void Start()
    {
        randomInt = 0;
        for (int i = 0; i < cardTypeAmount; i++)
        {
            for (int x = 0; x < existingCards.Count; x++)
            {
                crisisDeck.Add(existingCards[x]);
            }

        }
        deckSize = crisisDeck.Count;
        //Shuffle();

        staticDeck = crisisDeck;
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            CountOccurrences(existingCards[0]);
        }
        
    }

    // Fisher-Yates Shuffle Algorithm
    // https://www.youtube.com/watch?v=V8vGlC2ZB_g
    //public void Shuffle()
    //{
    //    for (int i = 0; i < crisisDeck.Count; i++)
    //    {
    //        int r = (int)(Random.value * (crisisDeck.Count - i));
    //        //Debug.Log(i+":"+r);
    //        //Debug.Log(deck.Count - i);
    //        CardData temp = crisisDeck[r];
    //        crisisDeck[r] = crisisDeck[i];
    //        crisisDeck[i] = temp;
    //    }
    //}

    // Check if all cards are there
    public int CountOccurrences(CardData item)
    {
        List<CardData> occurrences = crisisDeck.FindAll(i => i == item);
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
