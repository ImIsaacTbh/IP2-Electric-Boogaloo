using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    // public void Level1()
    // {
    //     //opens level1
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    // }
    //
    // public void Level2()
    // {
    //     //openslevel2
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    // }
    //
    // public void Home()
    // {
    //     //back to main menu
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    // }
}
