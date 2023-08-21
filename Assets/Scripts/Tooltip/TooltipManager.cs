using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    float delay = 0.5f;
    public string header;

    [Multiline()]
    public string content;

    private Coroutine tooltipCoroutine;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (tooltipCoroutine != null)
        {
            StopCoroutine(tooltipCoroutine);
        }

        Debug.Log(gameObject.name);

        tooltipCoroutine = StartCoroutine(TooltipDelay());
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        if (tooltipCoroutine != null)
        {
            StopCoroutine(tooltipCoroutine);
            tooltipCoroutine = null;
        }

        TooltipSingleton.HideTooltip();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (tooltipCoroutine != null)
        {
            StopCoroutine(tooltipCoroutine);
            tooltipCoroutine = null;
        }

        TooltipSingleton.HideTooltip();
    }

    IEnumerator TooltipDelay()
    {
        yield return new WaitForSeconds(delay);

        string description = content;
        string name = header;

        switch (gameObject.name)
        {
            case "LifeGoal1":
                description = PlayerGoals.goalDataSaved1.goalDescription;
                name = PlayerGoals.goalDataSaved1.goalName;
                break;
            case "LifeGoal2":
                description = PlayerGoals.goalDataSaved2.goalDescription;
                name = PlayerGoals.goalDataSaved2.goalName;
                break;
            case "LifeGoal3":
                description = PlayerGoals.goalDataSaved3.goalDescription;
                name = PlayerGoals.goalDataSaved3.goalName;
                break;
        }

        TooltipSingleton.ShowTooltip(description, name);
    }
}
