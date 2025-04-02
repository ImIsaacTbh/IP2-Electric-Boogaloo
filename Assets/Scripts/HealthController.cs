using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public GlobalController controller;

    public TMP_Text healthTXT;
    
    public Sprite[] healthBarImages;
    public Image healthBar;

     
    private void Update()
    {
        healthTXT.text = "Health: " + controller._health.ToString();
        if (controller._health == 100)
        {
            healthBar.sprite = healthBarImages[0];
            
        }
        if (controller._health < 100 && controller._health >= 70)
        {
            healthBar.sprite = healthBarImages[1];
        }
        if (controller._health < 70 && controller._health >= 50)
        {
            healthBar.sprite = healthBarImages[2];
        }
        if (controller._health == 50)
        {
            healthBar.sprite = healthBarImages[3];
        }
        if (controller._health < 50 && controller._health >= 30)
        {
            healthBar.sprite = healthBarImages[4];
        }
        if (controller._health < 30 && controller._health >= 0)
        {
            healthBar.sprite = healthBarImages[5];
        }
        
        if (controller._health <= 0)
        {
            healthBar.sprite = null;
        }

    }

    
}
