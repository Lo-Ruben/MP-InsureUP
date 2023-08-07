using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public CardDisplay cardDisplay { get; set; }
    [SerializeField]
<<<<<<< Updated upstream
    PlayerManager playerManager;
=======
    GameManager m_GameManager;

>>>>>>> Stashed changes
    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null && m_GameManager != null)
        {
            draggable.parentToReturnTo = this.transform;
            cardDisplay = draggable.GetComponent<CardDisplay>();
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            playerManager.EndTurn();
=======
            m_GameManager.PlayCard();
>>>>>>> Stashed changes
=======
            playerManager.PlayCard();
            draggable.IsDraggingStop = true;
>>>>>>> Stashed changes
        }
        if(draggable == null)
        {
            Debug.Log("Please put a card in the discard pile");
        }
        if(m_GameManager == null)
        {
            Debug.Log("PlayerManager is not referened in DropArea");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        

    }
    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
