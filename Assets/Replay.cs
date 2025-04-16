using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReplayOnDeath : MonoBehaviour
{
    public GameObject replayButton; // Assign the button in the inspector
    private bool isPlayerDead = false;

    void Start()
    {


        // Add a click listener to the button
        replayButton.GetComponent<Button>().onClick.AddListener(ReplayScene);
    }





    // Reloads the current scene
    public void ReplayScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}