using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.
public class ShowInsurance : MonoBehaviour, IPointerDownHandler
{
    InsuranceDisplay getInsuranceDisplay;
    public GameObject insuranceInfoPrefab;
    public InsuranceInfo healthInsurance;
    public InsuranceInfo accidentInsurance;
    public InsuranceInfo criticalInsurance;
    public InsuranceInfo lifeInsurance;
    // Start is called before the first frame update
    void Start()
    {
        getInsuranceDisplay = gameObject.GetComponent<InsuranceDisplay>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(getInsuranceDisplay.InsuranceData.insuranceCategory);
        showInfo();
    }
    void showInfo()
    {
        switch (getInsuranceDisplay.InsuranceData.insuranceCategory)
        {
            case "Health":
                InsuranceInfoDisplay health = insuranceInfoPrefab.GetComponent<InsuranceInfoDisplay>();
                health.insuranceInfo = healthInsurance;
                break;
            case "Accident":
                InsuranceInfoDisplay accident = insuranceInfoPrefab.GetComponent<InsuranceInfoDisplay>();
                accident.insuranceInfo = accidentInsurance;
                break;
            case "Life":
                InsuranceInfoDisplay life = insuranceInfoPrefab.GetComponent<InsuranceInfoDisplay>();
                life.insuranceInfo = lifeInsurance;
                break;
            case "Critical Illness":
                InsuranceInfoDisplay critical = insuranceInfoPrefab.GetComponent<InsuranceInfoDisplay>();
                critical.insuranceInfo = criticalInsurance;
                break;
        }
    }
}
