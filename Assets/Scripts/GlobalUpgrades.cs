using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalUpgrades : MonoBehaviour
{
    private GlobalController _controller;
    public static GlobalUpgrades instance = null;
    public GameObject globalUpgradesButtons;
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
    public int tcrTotal = 0;
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
        int asiTotal = attackSpeedIncrease / 10;

        if (asiTotal <= 5)
        {
            asiTotaltext.text = asiTotal.ToString() + "/5";
            asiPercentage = attackSpeedIncrease / 100f;
        }
        else
        {
            print("already maxed");
        }
        globalUpgradesButtons.SetActive(false);
    }

    public void TowerCostReduce()
    {
        towerCostReduction -= 10;
        tcrTotal = (towerCostReduction / 10) * -1;

        if (tcrTotal <= 5)
        {
            tcrTotaltext.text = tcrTotal.ToString() + "/5";
            tcrPercentage = towerCostReduction / 100f;
        }
        else
        {
            print("already maxed");
        }

        if (tcrTotal > 1)
        {
            for (int i = 0; i < TowerSelector.instance.towers.Length; i++)
            {
                TowerSelector.instance.towers[i].GetComponent<TowerFunction>().TowerValue = TowerSelector.instance.towers[i].GetComponent<TowerFunction>().normTowerValue;
            }
        }

        for (int i = 0; i < TowerSelector.instance.towers.Length; i++)
        {
            TowerSelector.instance.towers[i].GetComponent<TowerFunction>().TowerValue += (TowerSelector.instance.towers[i].GetComponent<TowerFunction>().TowerValue * tcrPercentage);
        }
        globalUpgradesButtons.SetActive(false);
    }

    public void EnemySpeedReduce()
    {
        enemySpeedReduction -= 10;
        int esrTotal = (enemySpeedReduction / 10) * -1;

        if (esrTotal <= 5)
        {
            esrTotaltext.text = esrTotal.ToString() + "/5";

            esrPercentage = enemySpeedReduction / 100f;

            GlobalController.instance._enemyTickRate = 30;
            GlobalController.instance._enemyTickRate += GlobalController.instance._enemyTickRate * esrPercentage;
        }
        else
        {
            print("already maxed");
        }

        globalUpgradesButtons.SetActive(false);
    }
}
