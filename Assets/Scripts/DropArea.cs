using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{
    public int droppedCardInt;
    public CardDisplay cardDisplay { get; set; }

    [Header("Insert GameManagers Here")]
    [SerializeField]
    GameManager playerManager;

    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null && playerManager != null)
        {
            draggable.parentToReturnTo = this.transform;
            cardDisplay = draggable.GetComponent<CardDisplay>();
            playerManager.PlayCard();
            draggable.isDraggingStop = true;
        }
        if (draggable == null)
        {
            Debug.Log("Please put a card in the discard pile");
        }
        if (playerManager == null)
        {
            Debug.Log("PlayerManager is not referened in DropArea");
        }
    }
    private void OnDisable()
    {
        droppedCardInt = 0;
    }
}
