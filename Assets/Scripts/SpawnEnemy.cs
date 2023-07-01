using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that controls the spawning of enemy ships
/// </summary>
public class SpawnEnemy : MonoBehaviour
{
    /// <summary>
    /// Public int that stores the speed of enemy ships 
    /// </summary>
    public int enemySpeed;

    /// <summary>
    /// Public Rigidbody2D reference to a enemy ship's rigidbody
    /// </summary>
    public Rigidbody2D enemyShip;

    /// <summary>
    /// Private float used as a timer
    /// </summary>
    private float timer = 0f;

    /// <summary>
    /// Public GameObject reference to the location where enemies spawn at
    /// </summary>
    public GameObject enemySpawnLocation;

    /// <summary>
    /// Private Rigidbody2D reference to the cloned/spawned enemy ship's rigidbody
    /// </summary>
    private Rigidbody2D enemyClone;

    /// <summary>
    /// Private float used to determine when enemy can be spawned
    /// </summary>
    private float enemySpawnTimer = 3f;

    /// <summary>
    /// Private constant float that stores the amount the spawn rate should change by
    /// </summary>
    private const float SPAWNRATECHANGE = 0.005f;

    /// <summary>
    /// Private constant int that stores maximum x distance that enemies can spawn from spawn location
    /// </summary>
    private const int SPAWNLOCVARY = 10;

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // If enemy can be spawned, call EnemySpawn()
        if (timer >= enemySpawnTimer)
        {
            EnemySpawn();
        }

        // Slowly make enemies spawn faster once a certain point has been reached
        if (enemySpawnTimer > 0.5)
        { 
            enemySpawnTimer -= SPAWNRATECHANGE;
        }

        // Keeps enemySpawnTimer from becoming negative
        else if (enemySpawnTimer < 0)
            enemySpawnTimer = 0.5f;
    }

    /// <summary>
    /// Private method that spawns an enemy ship 
    /// </summary>
    private void EnemySpawn()
    {
        int ranLocation = Random.Range(-SPAWNLOCVARY, SPAWNLOCVARY);
        enemyClone = Instantiate(enemyShip, new Vector2(enemySpawnLocation.transform.position.x + ranLocation, enemySpawnLocation.transform.position.y), transform.rotation);
        enemyClone.velocity = Vector2.down * enemySpeed;
        timer = 0f;

    }
}
