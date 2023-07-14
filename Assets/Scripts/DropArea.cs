using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public CardDisplay cardDisplay { get; set; }
    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null)
        {
            draggable.parentToReturnTo = this.transform;
            cardDisplay = draggable.GetComponent<CardDisplay>();
            //Debug.Log(cardDisplay.cardInfo);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        

    }
    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
