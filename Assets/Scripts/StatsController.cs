using System;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;


public class StatsController : MonoBehaviour
{
    [SerializeField] private float startTowerHealth;
    [SerializeField] private float startCurrency;

    private float currency;
    private float towerHealth;

    public TMP_Text healthText;
    public TMP_Text currencyText;

    public GameObject gameOver;


    private void Start()
    {
        healthText.text = "Health: " + startTowerHealth.ToString();
        currencyText.text = "Coins: " + startCurrency.ToString();

        //sets the tower health and currency to their start values
        towerHealth = startTowerHealth;
        currency = startCurrency;
    }

    public void IncreaseCurrency(float ammount) //Increases the currency
    {
        currency += ammount;
        currencyText.text = "Coins: " + currency.ToString();

    }
    public void DecreaseCurrency(float ammount) //Decreases the currency
    {
        currency -= ammount;
        currencyText.text = "Coins: " + currency.ToString();
    }

    public void IncreaseHealth(float ammount) //Increases the Tower's Health
    {
        towerHealth += ammount;
        healthText.text = "Health: " + towerHealth.ToString();
    }
    public void DecreaseHealth(float ammount) //Decreases the Tower's Health
    {
        towerHealth -= ammount;
        healthText.text = "Health: " + towerHealth.ToString();

        if (towerHealth <= 0)
        {
            Die();
        }
    }


    public void Die()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }
  
}


