using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object has the tag "Player"
        if (other.CompareTag("Player"))
        {
            finishSound.Play();
            Invoke("CompleteLevel", 2f);
        }

    }

    private void CompleteLevel() //ends scene
    {
        SceneManager.LoadScene(1);
    }
}
