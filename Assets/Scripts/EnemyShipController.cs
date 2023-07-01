using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script that controls the behaviour of enemy ships
/// </summary>
public class EnemyShipController : MonoBehaviour
{
    /// <summary>
    /// Private reference to AudioController script
    /// </summary>
    private AudioController audioController;

    /// <summary>
    /// Private reference to GameController script
    /// </summary>
    private GameController gameController;

    void Start()
    {
        // Initialises audioController and gameController
        audioController = GameObject.Find("Audio Controller").GetComponent<AudioController>();
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the enemy ship has collided with a laser, destroy the ship and increase the score
        if (collision.gameObject.tag == "Laser")
        {
            audioController.PlayExplosionSFX();
            gameController.AddScore(10);
            Destroy(gameObject);
        }

        // Else if the enemy ship has collided with the player ship, destroy both
        else if (collision.gameObject.tag == "Player")
        {
            audioController.PlayExplosionSFX();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        
        // Else if the enemy ship has touched the barrier, destroy it
        else if (collision.gameObject.tag == "Barrier")
            Destroy(gameObject);

    }
}
