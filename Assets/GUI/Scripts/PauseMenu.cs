using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuName;
    public bool isPaused;
    public GameObject pauseScreen;

    public static PauseMenu instance;

    private void Awake() //makes this reusable in other scripts to pause there code
    {
        instance = this;
    }

    void Start()
    {
        
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
        if (isPaused)
        {
            
            isPaused = false;
            pauseScreen.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;//locks cursor if game is unpaused
            Cursor.visible = false;//hides pause menu
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;//unlocks cursor if game is paused
            isPaused = true;
            pauseScreen.SetActive(true);//shows pause menu
            Cursor.visible = true;  
        }
    }
    public void MainMenu()
    {
        //loads main menu scene
        SceneManager.LoadScene(mainMenuName);
    }
}
