using System;
using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;

public class GlobalController : MonoBehaviour
{
    public static GlobalController instance = null;
    public Events Events = new Events();

    //Central Game Controls
    [Header("Central Controls")] 
    public float _centralTickRate = 60f;
    public bool _isGamePaused;

    [Header("User Controls")]
    public float volume;
    public bool isFullscreen;
    public Resolution resolution;

    [Header("Wave Controls")]
    public bool _isWaveInProgress;

    [Header("Tower Controls")]
    public float _towerTickRate = 60f;

    [Header("Enemy Controls")]
    public float _enemyTickRate = 30f;

    //Tracking variables
    public static float _timeSinceLastCentralTick;

    //Tracking Methods
    public bool IsWaveInProgress()
    {
        return instance._isWaveInProgress;
    }
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    void Start()
    {
        Debug.Log("Started Central Controller");
    }
    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _timeSinceLastCentralTick += Time.deltaTime;
        if (!_isGamePaused && _timeSinceLastCentralTick > 1 / _centralTickRate)
        {
            Events.SendCentralTick(EventArgs.Empty);
        }
    }
}
