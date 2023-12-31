using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.
public class ShowInventory : MonoBehaviour, IPointerDownHandler
{
    InsuranceDisplay getInsuranceDisplay;
    public GameObject insuranceInfoPrefab;
    public InventoryData healthInsurance;
    public InventoryData accidentInsurance;
    public InventoryData criticalInsurance;
    public InventoryData lifeInsurance;

    public AudioClip select;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        getInsuranceDisplay = gameObject.GetComponent<InsuranceDisplay>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(getInsuranceDisplay.InsuranceData.insuranceCategory);
        showInfo();
        audioSource.clip = select;
        audioSource.Play();
    }
    void showInfo()
    {
        switch (getInsuranceDisplay.InsuranceData.insuranceCategory)
        {
            case "Health":
                InventoryDisplay health = insuranceInfoPrefab.GetComponent<InventoryDisplay>();
                health.InventoryData = healthInsurance;
                break;
            case "Accident":
                InventoryDisplay accident = insuranceInfoPrefab.GetComponent<InventoryDisplay>();
                accident.InventoryData = accidentInsurance;
                break;
            case "Life":
                InventoryDisplay life = insuranceInfoPrefab.GetComponent<InventoryDisplay>();
                life.InventoryData = lifeInsurance;
                break;
            case "Critical Illness":
                InventoryDisplay critical = insuranceInfoPrefab.GetComponent<InventoryDisplay>();
                critical.InventoryData = criticalInsurance;
                break;
        }
    }
}
