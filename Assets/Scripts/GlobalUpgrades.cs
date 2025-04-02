using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlobalUpgrades : MonoBehaviour
{
    private GlobalController _controller;
    public static GlobalUpgrades instance = null;
    public GameObject upgradeButtons;
    public TextMeshPro asiTotaltext;
    public TextMeshPro tcrTotaltext;
    public TextMeshPro esrTotaltext;
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
        if (attackSpeedIncrease == 50)
        {

        }

        attackSpeedIncrease += 10;
        int total = attackSpeedIncrease / 10;

        asiPercentage = attackSpeedIncrease / 100f;

        upgradeButtons.SetActive(false);
    }

    public void TowerCostReduce()
    {
        if (towerCostReduction == -50)
        {

        }

        towerCostReduction -= 10;
        int total = towerCostReduction / 10;

        tcrPercentage = towerCostReduction / 100f;

        upgradeButtons.SetActive(false);
    }

    public void EnemySpeedReduce()
    {
        if (enemySpeedReduction == -50)
        {
            
        }

        enemySpeedReduction -= 10;
        int total = enemySpeedReduction / 10;

        esrPercentage = enemySpeedReduction / 100f;
        GlobalController.instance._enemyTickRate += GlobalController.instance._enemyTickRate * espPercentage;

        upgradeButtons.SetActive(false);
    }

    public void none()
    {
        upgradeButtons.SetActive(false);
    }
}
