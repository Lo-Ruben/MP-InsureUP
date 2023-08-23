using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentActive : MonoBehaviour
{
    public GameObject ContentHolders;

    private void Update()
    {
        bool anyChildActive = false;

        for (int i = 0; i < ContentHolders.transform.childCount; i++)
        {
            if (ContentHolders.transform.GetChild(i).gameObject.activeSelf)
            {
                anyChildActive = true;
                break;
            }
            else
            {
                anyChildActive = false;
            }
        }

        gameObject.SetActive(anyChildActive);
    }
}
