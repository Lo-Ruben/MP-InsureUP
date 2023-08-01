using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandableMenu : MonoBehaviour
{
    public GameObject closed;
    public GameObject open;
    public GameObject info;


    public void ExpandOpen()
    {
        open.SetActive(true);
        closed.SetActive(false);
        info.SetActive(true);
    }

    public void ExpandClosed()
    {
        open.SetActive(false);
        closed.SetActive(true);
        info.SetActive(false);
    }
}
