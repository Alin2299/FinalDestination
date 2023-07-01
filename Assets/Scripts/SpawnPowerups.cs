using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that controls the spawning of powerups
/// </summary>
public class SpawnPowerups : MonoBehaviour
{

    /// <summary>
    /// Public float used for the powerup spawning timer
    /// </summary>
    public float powerupSpawnTimer;

    /// <summary>
    /// Private float used as a timer
    /// </summary>
    private float timer = 0f;

    /// <summary>
    /// Public GameObject reference to the powerup spawn location
    /// </summary>
    public GameObject powerupSpawnLocation;

    /// <summary>
    /// Public static int that stores the number of currently available powerups
    /// </summary>
    public static int numOfPowerups = 0;

    // Public GameObject references to the powerups 
    public GameObject shotgun;
    public GameObject minigun;

    /// <summary>
    /// Private constant int that stores the total types of powerups in the game
    /// </summary>
    private const int TYPESPOWERUPS = 2;

    /// <summary>
    /// Private constant int that stores maximum x distance that powerups can spawn from spawn location
    /// </summary>
    private const int SPAWNLOCVARY = 10;

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // If a powerup can be spawned, call PowerupSpawn() and reset timer
        if (timer >= powerupSpawnTimer)
        {
            PowerupSpawn();
            timer = 0f;
        }
    }

    /// <summary>
    /// Private method that spawns a random powerup (only if no powerups are currently available)
    /// </summary>
    private void PowerupSpawn()
    {
        // Calculate random numbers for which powerup type to spawn, and where to spawn it
        int ranPowerup = Random.Range(1, TYPESPOWERUPS + 1);
        int ranLocation = Random.Range(-SPAWNLOCVARY, SPAWNLOCVARY);

        if (ranPowerup == 1 && numOfPowerups == 0)
        {
            GameObject ShotgunClone = Instantiate(shotgun, new Vector2(powerupSpawnLocation.transform.position.x + ranLocation, powerupSpawnLocation.transform.position.y), transform.rotation) as GameObject;
        }

        if (ranPowerup == 2 && numOfPowerups == 0)
        {
            GameObject MinigunClone = Instantiate(minigun, new Vector2(powerupSpawnLocation.transform.position.x + ranLocation, powerupSpawnLocation.transform.position.y), transform.rotation) as GameObject;
        }
        numOfPowerups++;
    }
}
