using Assets;
using Assets.Enemy.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public int _waveNumber = 1;
    public bool _waitingForWaveStart = false;
    public bool _isWaveInProgress = false;

    [Header("Tower Controls")]
    public float _towerTickRate = 60f;

    [Header("Enemy Controls")]
    public float _enemyTickRate = 30f;

    public float _globalEnemySpawnRate = 0.5f;

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
        Events.TryStartWave += TryStartWave;
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

    void TryStartWave(object sender, EventArgs e)
    {
        if (!_isWaveInProgress)
        {
            _isWaveInProgress = true;
            Events.SendWaveStart(EventArgs.Empty);
        }
    }
}

public static class HelpfulShit
{
    public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> list, int count)
    {
        return list.OrderBy(x => Guid.NewGuid()).Take(count);
    }

    public static T PickRandom<T>(this IEnumerable<T> list)
    {
        return list.PickRandom(1).Single();
    }

    public static string Debug(this Wave wave)
    {
        string output = String.Empty;
        output += $"------------WAVE DATA-----------\nWave Number: {GlobalController.instance._waveNumber}\nSpawn Interval: {wave.spawnInterval}\nTicks since last enemy spawn: {WaveManager.instance.ticksSinceLastSpawn}\n-----ENEMIES-----\n";
        foreach(var enemyType in wave.enemyBunches)
        {
            output += ($"Enemy: {enemyType.enemyPrefab.name} Count: {enemyType.count}\n");
        }
        output += ($"----------END WAVE DATA---------");
        return output;
    }
}
