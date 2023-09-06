using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;

    public GameManager gameManager;

    public List<GameObject> invCards = new List<GameObject>();

    public List<InsuranceData> boughtInsrData = new List<InsuranceData>();

    public AudioSource audioSource;
    public AudioClip openInvt;
    public AudioClip click;

    public int renewCount;

    // Start is called before the first frame update
    void Start()
    {
        renewCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayInventory()
    {
        for (int i = 0; i < boughtInsrData.Count; i++)
        {
            invCards[i].GetComponent<InsuranceDisplay>().InsuranceData = boughtInsrData[i];
        }
        ConditionalDisplay();
    }

    public void OpenInventory()
    {
        DisplayInventory();
        inventory.SetActive(true);
        audioSource.clip = openInvt;
        audioSource.Play();
    }

    public void CloseInventory()
    {
        inventory.SetActive(false);
        audioSource.clip = click;
        audioSource.Play();
    }

    public void ConditionalDisplay()
    {
        foreach (GameObject insrCard in invCards)
        {
            insrCard.SetActive(false);
        }
        for (int o = 0; o < boughtInsrData.Count; o++)
        {
            invCards[o].GetComponent<InsuranceDisplay>().DisplayInfo();
            invCards[o].SetActive(true);
        }
    }

    public void RenewalPayment()
    {
        Debug.Log("Renewal deducted");

        int cost = 0;
        if (renewCount < 1)
        {
            foreach (InsuranceData individualInsurance in boughtInsrData)
            {
                if (individualInsurance.boughtTurn < gameManager.roundCounter)
                {
                    cost += individualInsurance.cardCost;
                    Debug.Log("Renewal cost: " + cost);
                }
                Debug.Log("Money Left: " + (gameManager.money - cost));
            }

            gameManager.money -= cost;

            renewCount++;
        }
        

    }
}
