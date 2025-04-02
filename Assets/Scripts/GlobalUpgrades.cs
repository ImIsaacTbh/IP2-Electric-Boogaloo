using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalUpgrades : MonoBehaviour
{
    private GlobalController _controller;
    public static GlobalUpgrades instance = null;
    [Header("Global Upgrade Values")]
    public int attackSpeedIncrease;
    public int towerCostReduction;
    public int enemySpeedReduction;
    public float asiPercentage;
    public float tcrPercentage;
    public float espPercentage;
    void Start()
    {
        _controller = GlobalController.instance;
        if (instance == null)
        {
            instance = this;
        }
    }
    public void AttackSpeedIncrease()
    {
        attackSpeedIncrease += 10;
        int total = attackSpeedIncrease / 10;

        asiPercentage = attackSpeedIncrease / 100f;
    }

    public void TowerCostReduce()
    {
        towerCostReduction -= 10;
        int total = towerCostReduction / 10;

        tcrPercentage = towerCostReduction / 100f;
    }

    public void EnemySpeedReduce()
    {
        enemySpeedReduction -= 10;
        int total = enemySpeedReduction / 10;

        espPercentage = enemySpeedReduction / 100f;
        GlobalController.instance._enemyTickRate += GlobalController.instance._enemyTickRate * espPercentage;
        
    }
}
