using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrisisDeck : MonoBehaviour
{
    public static int deckSize;
    int randomInt;
    int cardTypeAmount = 2;

    public List<CrisisData> crisisDeck = new List<CrisisData>();
    public static List<CrisisData> staticDeck = new List<CrisisData>();
    public List<CrisisData> existingCards = new List<CrisisData>();

    // Counter for random crisis chance
    public int disasterCounter = 10;

    [Header("Adjust Crisis chance of appearing")]
    [SerializeField]
    int minDisasterCardChance;
    [SerializeField]
    int maxDisasterCardChance;

    [Header("Reference CrisisDisplay")]
    [SerializeField]
    CrisisDisplay crisisDisplay;

    void Start()
    {
        for (int i = 0; i < cardTypeAmount; i++)
        {
            for (int x = 0; x < existingCards.Count; x++)
            {
                crisisDeck.Add(existingCards[x]);
            }

        }
        deckSize = crisisDeck.Count;
        Shuffle();
        RandomChance();

        staticDeck = crisisDeck;
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            CountOccurrences(existingCards[0]);
        }
        if (randomInt == disasterCounter)
        {
            ReduceDeck();
            disasterCounter = 10;
            RandomChance();

        }
        if (randomInt >= disasterCounter)
        {
            Debug.Log("Gone out of something wrong with disasterCounter");
        }

    }

    // Fisher-Yates Shuffle Algorithm
    // https://www.youtube.com/watch?v=V8vGlC2ZB_g
    public void Shuffle()
    {
        for (int i = 0; i < crisisDeck.Count; i++)
        {
            int r = (int)(Random.value * (crisisDeck.Count - i));
            //Debug.Log(i+":"+r);
            //Debug.Log(deck.Count - i);
            CrisisData temp = crisisDeck[r];
            crisisDeck[r] = crisisDeck[i];
            crisisDeck[i] = temp;
        }
    }

    // Check if all cards are there
    public int CountOccurrences(CrisisData item)
    {
        List<CrisisData> occurrences = crisisDeck.FindAll(i => i == item);
        Debug.Log(occurrences.Count);
        return occurrences.Count;
    }

    void RandomChance()
    {
        randomInt = Random.Range(minDisasterCardChance,maxDisasterCardChance);
        Debug.Log("RandomInt:"+randomInt);
        
    }

    public void ReduceDeck()
    {
        crisisDisplay.CrisisInfo = staticDeck[staticDeck.Count - 1];
        staticDeck.RemoveAt(staticDeck.Count - 1);
        deckSize -= 1;
    }
}
