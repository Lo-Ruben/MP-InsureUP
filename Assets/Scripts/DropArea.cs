using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{
    public int droppedCardInt;
    public CardData cardData { get; set; }

    [Header("Insert GameManagers Here")]
    [SerializeField]
    GameManager gameManager;

    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null && gameManager != null)
        {
            draggable.parentToReturnTo = this.transform;
            cardData = draggable.GetComponent<CardDisplay>().CardInfo;
            gameManager.PlayCard();
            draggable.isDraggingStop = true;
        }
        if (draggable == null)
        {
            Debug.Log("Please put a card in the discard pile");
        }
        if (gameManager == null)
        {
            Debug.Log("PlayerManager is not referened in DropArea");
        }

        droppedCardInt += 1;
    }
    private void OnDisable()
    {
        
    }
}
