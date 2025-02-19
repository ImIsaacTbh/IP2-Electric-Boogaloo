using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool Alive = true;
    public AudioClip gameOverAudioClip; // Reference to the audio clip
    private AudioSource audioSource; // Reference to the audio source
    public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = gameOverAudioClip;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
       // {
       //     TakeDamage(20);
       // }
        // Check if health is zero or below
        if (currentHealth <= 0)
        {
            Alive = false; // Set Alive to false
            PlayGameOverAudio(); // Play the audio clip
           
            enabled = false;
        }

    }

    void PlayGameOverAudio()
    {
        //playes audio
        audioSource.Play();
        StartCoroutine(WaitForAudioToFinish());

    }
    IEnumerator WaitForAudioToFinish()
    {
        // Wait until the audio clip finishes playing
        
        yield return new WaitForSeconds(2);
        ResetScene();
    }

    public void TakeDamage(int damage)
    {
        //takes damage and change sthe health bar
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }


    void ResetScene()
    {
        // Reset the scene called "Nathans Project"
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}