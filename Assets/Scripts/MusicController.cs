using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script that manages the music of the game
/// </summary>
public class MusicController : MonoBehaviour
{
    /// <summary>
    /// Private reference to AudioSource of the music controller
    /// </summary>
    private AudioSource musicController;

    // Public AudioClips of the music in the game 
    public AudioClip menuMusic;
    public AudioClip mainMusic;

    /// <summary>
    /// Public static int representing the volume of the music
    /// </summary>
    public static int musicVolume;

    void Start()
    {
        // Initialise musicController
        musicController = GetComponent<AudioSource>();

        // If currently in the Main Menu, play the menu music
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            musicController.clip = menuMusic;
            musicController.Play();
        }

        // Else if currently in-game, play the main (game) music
        else if (SceneManager.GetActiveScene().name == "Main")
        {
            musicController.clip = mainMusic;
            musicController.Play();
        }
    }

    /// <summary>
    /// Public method that stops the (current) music's playback
    /// </summary>
    public void StopMusic()
    {
        musicController.Stop();
    }
}
