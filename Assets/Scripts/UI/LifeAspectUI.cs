using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeAspectUI : MonoBehaviour
{
    public GameManager gameManager;
    public List<Sprite> numberSprites;

    private Image imageComponent;

    private void Awake()
    {
        imageComponent = GetComponent<Image>();
    }
    public void UpdateJobImage()
    {
        if (gameManager != null)
        {
            int JobNumber = gameManager.jobLevel;
            int JobspriteIndex = JobNumber;

            if (JobspriteIndex >= 0 && JobspriteIndex < numberSprites.Count)
            {
                imageComponent.sprite = numberSprites[JobspriteIndex];
            }
        }
    }
    public void UpdateFamilyImage()
    {
        int FamNumber = gameManager.familyLevel;
        int FamspriteIndex = FamNumber;

        if (FamspriteIndex >= 0 && FamspriteIndex < numberSprites.Count)
        {
            imageComponent.sprite = numberSprites[FamspriteIndex];
        }
    }
    public void UpdatePersonalImage()
    {
        int PersonalNumber = gameManager.personalLevel;
        int PersonalspriteIndex = PersonalNumber;

        if (PersonalspriteIndex >= 0 && PersonalspriteIndex < numberSprites.Count)
        {
            imageComponent.sprite = numberSprites[PersonalspriteIndex];
        }
    }
}
