using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrisisDeck : MonoBehaviour
{
    int cardTypeAmount = 2;

    public List<CrisisData> crisisDeck = new List<CrisisData>();
    public static List<CrisisData> staticDeck = new List<CrisisData>();
    public List<CrisisData> existingCards = new List<CrisisData>();

    [Header("Reference CrisisDisplay")]
    [SerializeField]
    CrisisDisplay crisisDisplay;

    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    bool wasInvoked = false;

    void Start()
    {
        for (int i = 0; i < cardTypeAmount; i++)
        {
            for (int x = 0; x < existingCards.Count; x++)
            {
                crisisDeck.Add(existingCards[x]);
            }

        }
        Shuffle();

        staticDeck = crisisDeck;
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            CountOccurrences(existingCards[0]);
        }
        ShowCrisis();
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


    public void ReduceDeck()
    {
        if(crisisDeck.Count > 0)
        {
            crisisDisplay.CrisisInfo = staticDeck[staticDeck.Count - 1];
            staticDeck.RemoveAt(staticDeck.Count - 1);
        }
        else
        {
            Debug.Log("No More Crisis Cards");
        }
        
    }
    public void ShowCrisis()
    {
        if (gameManager.PhaseInt == 4)
        {
            if (!wasInvoked)
            {
                wasInvoked = true;
                ReduceDeck();
            }
        }
        else
        {
            wasInvoked = false;
        }
    }
}
