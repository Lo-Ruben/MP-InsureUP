using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject lifeGoalsSelect;
    public GameObject drawCards;
    public GameObject playCards;
    public GameObject viewGoals;
    public GameObject endPhases;
    public GameObject buyInsurance;
    public GameObject inventory;
    public GameObject info;

    public void lifeGoal()
    {
        lifeGoalsSelect.SetActive(true);
        drawCards.SetActive(false);
        playCards.SetActive(false);
        viewGoals.SetActive(false);
        endPhases.SetActive(false);
        buyInsurance.SetActive(false);
        inventory.SetActive(false);
        info.SetActive(false);
    }
    public void draw()
    {
        lifeGoalsSelect.SetActive(false);
        drawCards.SetActive(true);
        playCards.SetActive(false);
        viewGoals.SetActive(false);
        endPhases.SetActive(false);
        buyInsurance.SetActive(false);
        inventory.SetActive(false);
        info.SetActive(false);
    }
    public void play()
    {
        lifeGoalsSelect.SetActive(false);
        drawCards.SetActive(false);
        playCards.SetActive(true);
        viewGoals.SetActive(false);
        endPhases.SetActive(false);
        buyInsurance.SetActive(false);
        inventory.SetActive(false);
        info.SetActive(false);
    }
    public void view()
    {
        lifeGoalsSelect.SetActive(false);
        drawCards.SetActive(false);
        playCards.SetActive(false);
        viewGoals.SetActive(true);
        endPhases.SetActive(false);
        buyInsurance.SetActive(false);
        inventory.SetActive(false);
        info.SetActive(false);
    }
    public void end()
    {
        lifeGoalsSelect.SetActive(false);
        drawCards.SetActive(false);
        playCards.SetActive(false);
        viewGoals.SetActive(false);
        endPhases.SetActive(true);
        buyInsurance.SetActive(false);
        inventory.SetActive(false);
        info.SetActive(false);
    }
    public void buy()
    {
        lifeGoalsSelect.SetActive(false);
        drawCards.SetActive(false);
        playCards.SetActive(false);
        viewGoals.SetActive(false);
        endPhases.SetActive(false);
        buyInsurance.SetActive(true);
        inventory.SetActive(false);
        info.SetActive(false);
    }
    public void invent()
    {
        lifeGoalsSelect.SetActive(false);
        drawCards.SetActive(false);
        playCards.SetActive(false);
        viewGoals.SetActive(false);
        endPhases.SetActive(false);
        buyInsurance.SetActive(false);
        inventory.SetActive(true);
        info.SetActive(false);
    }
    public void infocard()
    {
        lifeGoalsSelect.SetActive(false);
        drawCards.SetActive(false);
        playCards.SetActive(false);
        viewGoals.SetActive(false);
        endPhases.SetActive(false);
        buyInsurance.SetActive(false);
        inventory.SetActive(false);
        info.SetActive(true);
    }

}
