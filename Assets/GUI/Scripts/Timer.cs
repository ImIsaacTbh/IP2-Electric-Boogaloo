using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    GlobalController _controller;
    public float timeRemaining = 0;
    public bool timeIsRunning = true;
    public TMP_Text timeText;
    void Start()
    {
        _controller = GlobalController.instance;
        timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_controller._isGamePaused == false) //if paused pause timer
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
