using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script that manages the (non-music) audio of the game
/// </summary>
public class AudioController : MonoBehaviour
{
    /// <summary>
    /// AudioSource of the controller
    /// </summary>
    private AudioSource audioController;

    // Public AudioClips for the different audio that will be played
    public AudioClip laserFire;
    public AudioClip shipExplosion;

    /// <summary>
    /// Public static float representing the volume (scale) of the audio/SFX
    /// </summary>
    public static float audioVolume = 0.5f;

    void Start()
    {
        // Initialises audioController
        audioController = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Public method that plays the laser firing SFX using PlayOneShot()
    /// </summary>
    public void PlayLaserFireSFX()
    {
        audioController.PlayOneShot(laserFire, audioVolume);
    }

    /// <summary>
    /// Public method that plays the (ship) explosion SFX using PlayOneShot()
    /// </summary>
    public void PlayExplosionSFX()
    {
        audioController.PlayOneShot(shipExplosion, audioVolume);
    }
}
