using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeAspectUI : MonoBehaviour
{
    // Script manages the bar progression for Job, Personal and Life levels

    public GameManager gameManager;
    public List<Sprite> numberSprites;

    private Image imageComponent;

    private void Awake()
    {
        imageComponent = GetComponent<Image>();
    }
    public void UpdateImage(int spriteIndex)
    {
        if (gameManager != null && spriteIndex >= 0 && spriteIndex < numberSprites.Count)
        {
            imageComponent.sprite = numberSprites[spriteIndex];
        }
    }
}
