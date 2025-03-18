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
        // Pauses game
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
            Cursor.lockState = CursorLockMode.Locked; // Locks cursor if game is unpaused
            Cursor.visible = false; // Hides pause menu
            _controller.Events.SendUnPause(EventArgs.Empty);
        }
        else
        {
            _controller._isGamePaused = true;
            pauseScreen.SetActive(true); // Shows pause menu
            Cursor.visible = true;
            _controller.Events.SendPause(EventArgs.Empty);
        }
    }

    public void MainMenu()
    {
        Debug.Log("did thing");
        // Loads main menu scene
        SceneManager.LoadScene(mainMenuName);
    }

    public void Replay()
    {
        Debug.Log("Reloading current scene");
        // Reloads the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
