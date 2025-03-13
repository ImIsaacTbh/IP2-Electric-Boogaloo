using System.Collections;
using System.Collections.Generic;
using Assets;
using Assets.Enemy.Scripts;
using UnityEngine;

public class DebugInfoHandler : MonoBehaviour
{
    public GlobalController _controller;

    public bool IsWave;
    public bool IsOverall;


    // Start is called before the first frame update
    void Start()
    {
        _controller = GlobalController.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsWave)
        try
        {
            GetComponent<TMPro.TextMeshProUGUI>().text = WaveManager.instance.currentWave.Debug();
        }
        catch {
            GetComponent<TMPro.TextMeshProUGUI>().text = "No Wave";
        }
        if(IsOverall)
        try
        {
            GetComponent<TMPro.TextMeshProUGUI>().text = $"------------GAME DATA-----------\nWave Number : {GlobalController.instance._waveNumber}\nEnemies alive : {EnemyController.instance._enemiesInPlay.Count.ToString()}\nWave In-Progress? : {GlobalController.instance._isWaveInProgress}\n---------END GAME DATA----------";
        }
        catch {
            GetComponent<TMPro.TextMeshProUGUI>().text = "No Data";
        }
    }
}
