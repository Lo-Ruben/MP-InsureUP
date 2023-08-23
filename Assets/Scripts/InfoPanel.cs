using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    public GameObject info;
    public void OpenInfo()
    {
        info.SetActive(true);
    }
    public void CloseInfo()
    {
        info.SetActive(false);
    }
}
