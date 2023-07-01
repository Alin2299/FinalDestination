using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that controls the movement of the lasers in the game
/// </summary>
public class LaserMovement : MonoBehaviour
{
    /// <summary>
    /// Private Rigidbody2D representing the laser's rb
    /// </summary>
    private Rigidbody2D laser;

    /// <summary>
    /// Private int representing the speed of the lasers
    /// </summary>
    private int laserSpeed = 15;

    private void Start()
    {
        // Initialise the laser rigidbody
        laser = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move the laser at the desired speed (upwards)
        laser.velocity = transform.TransformDirection(Vector2.up * laserSpeed);
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the laser has collided with a barrier, destroy the laser
        if (collision.gameObject.tag == "Barrier")
            Destroy(gameObject);
    }
}
