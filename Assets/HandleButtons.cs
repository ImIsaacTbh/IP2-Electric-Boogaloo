using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleButtons : MonoBehaviour
{
    private GlobalController _controller;
    private void Start()
    {
        _controller = GlobalController.instance;
    }

    public void AttemptStartWave()
    {
        _controller.Events.SendTryStartWave(EventArgs.Empty);
    }
}
