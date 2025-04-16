using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance = null;
    public GlobalController _controller;

    public List<GameObject> activeTowers = new List<GameObject>();
    public int ticksSinceLastTowerTick = 2;

    void Awake()
    {

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        _controller = GlobalController.instance;
        _controller.Events.CentralTick += OnCentralTick;
        _controller.Events.ResetWave += (object sender, EventArgs e) => {
            foreach (GameObject tower in activeTowers)
            {
                tower.GetComponent<TowerFunction>().inRangeEnemies.Clear();
            }
        };
    }

    private void OnCentralTick(object sender, EventArgs e)
    {
        ticksSinceLastTowerTick++;
        print("checking if tower tick due");
        if (ticksSinceLastTowerTick >= _controller._towerTickRate)
        {
            print("Sent tower tick");
            _controller.Events.SendTowerTick(EventArgs.Empty);
            ticksSinceLastTowerTick = 0;
        }
    }
}
