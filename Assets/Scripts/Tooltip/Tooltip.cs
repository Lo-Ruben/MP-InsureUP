using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public Text headerText;

    public Text contentText;

    public LayoutElement layoutElement;

    public int characterWrapLimit;

    public RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetText(string content, string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            Debug.Log("Empty header");
            headerText.gameObject.SetActive(false);
        }
        else
        {
            headerText.gameObject.SetActive(true);
            headerText.text = header;
        }

        contentText.text = content;

        // Controls when layout element of the tooltip will be enabled/disabled
        int headerLength = headerText.text.Length;
        int contentLength = contentText.text.Length;

        layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
    }

    private void Update()
    {
        if (Application.isEditor)
        {
            UpdateLayoutElement();
        }

        UpdatePivotAndPosition();
    }

    private void UpdateLayoutElement()
    {
        int headerLength = headerText.text.Length;
        int contentLength = contentText.text.Length;
        layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit);
    }

    private void UpdatePivotAndPosition()
    {
        Vector2 position = Input.mousePosition;

        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        Vector2 newPivot;

        if (pivotX <= pivotY && pivotX <= 1 - pivotY) // left
            newPivot = new Vector2(-0.15f, pivotY);
        else if (pivotX >= pivotY && pivotX <= 1 - pivotY) // bottom
            newPivot = new Vector2(pivotX, -0.1f);
        else if (pivotX >= pivotY && pivotX >= 1 - pivotY) // right
            newPivot = new Vector2(1.1f, pivotY);
        else // top
            newPivot = new Vector2(pivotX, 1.3f);

        rectTransform.pivot = newPivot;
        transform.position = position;
    }
}
