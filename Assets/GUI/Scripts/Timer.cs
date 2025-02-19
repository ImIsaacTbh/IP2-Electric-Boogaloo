using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    public float timeRemaining = 0;
    public bool timeIsRunning = true;
    public TMP_Text timeText;
    void Start()
    {
        timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.instance.isPaused == false) //if paused pause timer
        {
            if (timeIsRunning)
            {
                if (timeRemaining >= 0)
                {
                    timeRemaining += Time.deltaTime;
                    DisplayTime(timeRemaining);
                }
            }
        }
    }

    void DisplayTime (float timeToDisplay)
    {
        timeToDisplay += 1; //formats and add seconds to the clock and whne reaching 60s show sas 1:00
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
