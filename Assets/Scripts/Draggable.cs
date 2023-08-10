using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, /*IPointerDownHandler, */IBeginDragHandler, IEndDragHandler, IDragHandler{
    // Cards are stored in the canvas instead of the game scene
    
    public Transform parentToReturnTo { get; set; }
    private RectTransform rectTransform;

    [SerializeField]private Canvas canvas;

    private CanvasGroup canvasGroup;

    public bool isDraggingStop = false;

    private void Awake()
    {
        // Manually reference canvas, check if there is a performance issue
        GameObject canvasObject = GameObject.Find("Canvas");
        canvas = canvasObject.GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    //Debug.Log("PointerDown");
    //}
    public void OnDrag(PointerEventData eventData)
    {
        if (isDraggingStop)
        {
            
            return;
        }
        rectTransform.anchoredPosition += eventData.delta/ canvas.scaleFactor;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isDraggingStop)
        {
            
            return;
        }
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(canvas.transform);
        
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("DragEnd");
        if (isDraggingStop)
        {
            
            this.transform.SetParent(parentToReturnTo);
            canvasGroup.alpha = 1f;
            return;
        }
        this.transform.SetParent(parentToReturnTo);
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");
        if (isDraggingStop)
        {
            
            return;
        }
        this.transform.SetParent(parentToReturnTo);
        throw new System.NotImplementedException();
    }
}
