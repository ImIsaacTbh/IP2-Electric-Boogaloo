using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Enemy.Scripts;
using UnityEngine;

public class HandleButtons : MonoBehaviour
{
    private GlobalController _controller;
    public GameObject TowerSelectionUI;
    public bool isTowerSelectionOpen = false;
    private void Start()
    {
        _controller = GlobalController.instance;
    }

    public void Update()
    {

    }

    public void AttemptStartWave()
    {
        _controller.Events.SendTryStartWave(EventArgs.Empty);
    }

    public void SkipWave()
    {
        WaveManager.instance.SkipWave();
    }

    public IEnumerator SmoothMove(Vector3 finalX)
    {
        TowerSelectionUI.transform.position = finalX;
        yield return null;
    }
    
    public void OpenSelectionOverlay()
    {
        StartCoroutine(SmoothMove(new Vector3(0, TowerSelectionUI.transform.position.y, TowerSelectionUI.transform.position.z)));
    }

    public void CloseSelectionOverlay()
    {
        StartCoroutine(SmoothMove(new Vector3(340, TowerSelectionUI.transform.position.y, TowerSelectionUI.transform.position.z)));
    }
    
}
