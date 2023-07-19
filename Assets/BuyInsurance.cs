using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.
public class BuyInsurance : MonoBehaviour, IPointerDownHandler
{
    InsuranceDisplay getInsuranceInfo;
    string insuranceType;
    [SerializeField]
    PlayerManager m_playerManager;
    public void OnPointerDown(PointerEventData eventData)
    {
        getInsuranceInfo = gameObject.GetComponent<InsuranceDisplay>();
        InsuranceBool();
    }

    void InsuranceBool()
    {
        switch (getInsuranceInfo.InsuranceData.cardName)
        {
            case "Health":
                Debug.Log("Health");
                m_playerManager.HealthInsurance = true;
                break;
            case "Critical Illness":
                Debug.Log("Critical Illness");
                m_playerManager.CriticalIllnessInsurance = true;
                break;
            case "Life":
                Debug.Log("Life");
                m_playerManager.LifeInsurance = true;
                break;
            case "Endownment":
                Debug.Log("Endownment");
                m_playerManager.EndownmentInsurance = true;
                break;
            default:
                print("Incorrect insurance.");
                break;
        }
    }
}
