using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventUpdate : MonoBehaviour
{
    public event EventHandler CheckGoals;

    private void Start()
    {
    }

    // Call event if conditions has been met
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    CheckGoals?.Invoke(this, EventArgs.Empty);
        //}

        CheckGoals?.Invoke(this, EventArgs.Empty);

    }
}
