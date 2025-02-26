using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); //Loads the given scene
    }

    public void QuitGame()
    {
        Debug.Log("QUITTED");
        Application.Quit(); //Quits the application
    }
}
