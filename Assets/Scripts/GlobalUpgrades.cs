using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalUpgrades : MonoBehaviour
{
    private GlobalController _controller;
    public static GlobalUpgrades instance = null;
    public TextMeshProUGUI asiTotaltext;
    public TextMeshProUGUI tcrTotaltext;
    public TextMeshProUGUI esrTotaltext;
    [Header("Global Upgrade Values")]
    public int attackSpeedIncrease;
    public int towerCostReduction;
    public int enemySpeedReduction;
    public float asiPercentage;
    public float tcrPercentage;
    public float esrPercentage;
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
        int total = attackSpeedIncrease / 10;
        if (total < 5)
        {
            attackSpeedIncrease += 10;

            asiTotaltext.text = total.ToString() + "/5";
            asiPercentage = attackSpeedIncrease / 100f;
        }


    }

    public void TowerCostReduce()
    {
        towerCostReduction -= 10;
        int total = (towerCostReduction / 10) * -1;

        tcrTotaltext.text = total.ToString() + "/5";
        tcrPercentage = towerCostReduction / 100f;
    }

    public void EnemySpeedReduce()
    {
        enemySpeedReduction -= 10;
        int total = (enemySpeedReduction / 10) * -1;

        esrTotaltext.text = total.ToString() + "/5";

        esrPercentage = enemySpeedReduction / 100f;
        GlobalController.instance._enemyTickRate += GlobalController.instance._enemyTickRate * esrPercentage;
        
    }
}
