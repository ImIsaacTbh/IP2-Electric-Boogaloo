using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    GlobalController _controller;

    public string mainMenuName;
    //public bool isPaused;
    public GameObject pauseScreen;

    public static PauseMenu instance;

    void Start()
    {
        instance = this;
        _controller = GlobalController.instance;
    }

    void Update()
    {
        //pauses game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            PauseUnPause();
        }
    }

    public void PauseUnPause()
    {
        if (_controller._isGamePaused)
        {

            _controller._isGamePaused = false;
            pauseScreen.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;//locks cursor if game is unpaused
            Cursor.visible = false;//hides pause menu
            _controller.Events.SendUnPause(EventArgs.Empty);
        }
        else
        {
            _controller._isGamePaused = true;
            pauseScreen.SetActive(true);//shows pause menu
            Cursor.visible = true;
            _controller.Events.SendPause(EventArgs.Empty);
        }
    }
    public void MainMenu()
    {
        Debug.Log("did thing");
        //loads main menu scene
        SceneManager.LoadScene(mainMenuName);
    }
}
