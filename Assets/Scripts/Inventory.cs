using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;

    public GameManager gameManager;

    public List<GameObject> invCards = new List<GameObject>();

    public List<InsuranceData> boughtInsrData = new List<InsuranceData>();

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    public void CloseInventory()
    {
        inventory.SetActive(false);
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
}
