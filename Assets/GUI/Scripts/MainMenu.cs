using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
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

    public void LoadingScreen(string sceneName)
    {
        Display.displays[1].Activate();
        StartCoroutine(switchDelay(sceneName, 5));
    }

    public IEnumerator switchDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}

