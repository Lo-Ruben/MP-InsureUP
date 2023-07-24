using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrisisDeck : MonoBehaviour
{
<<<<<<< Updated upstream
    public List<CardData> crisisDeck = new List<CardData>();
    public static List<CardData> staticDeck = new List<CardData>();
    public List<CardData> existingCards = new List<CardData>();
    public static int deckSize;
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        deckSize = crisisDeck.Count;
        //Shuffle();
=======
        Shuffle();
        RandomChance();
>>>>>>> Stashed changes

        staticDeck = crisisDeck;
    }
    void Update()
    {
        if (staticDeck.Count > 0)
        {
<<<<<<< Updated upstream
            CountOccurrences(existingCards[0]);
        }
        
=======
            if (randomInt == disasterCounter)
            {
                Debug.Log(staticDeck.Count);
                ReduceDeck();
                disasterCounter = 10;
                RandomChance();

            }
            if (randomInt >= disasterCounter)
            {
                Debug.Log("Gone out of something wrong with disasterCounter");
            }
        }
            

>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        staticDeck.RemoveAt(staticDeck.Count - 1);
        deckSize -= 1;

        //Debug.Log(deckSize);

=======
        randomInt = Random.Range(minDisasterCardChance,maxDisasterCardChance);
        Debug.Log("RandomInt:"+randomInt);
        
    }

    public void ReduceDeck()
    {
        //if(staticDeck.Count > 0)
        //{
            crisisDisplay.CrisisInfo = staticDeck[staticDeck.Count - 1];
            staticDeck.RemoveAt(staticDeck.Count - 1);
        //}
        
>>>>>>> Stashed changes
    }
}
