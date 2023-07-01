using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// Script that controls the movement/behaviour of the player ship
/// </summary>
public class ShipController : MonoBehaviour
{
    /// <summary>
    /// Public float that stores the movement speed of the player ship
    /// </summary>
    public float movementSpeed;

    /// <summary>
    /// Private Vector2 that tracks the current movement direction
    /// </summary>
    private Vector2 moveDirection;

    /// <summary>
    /// Private Rigidbody2D of the player ship
    /// </summary>
    private Rigidbody2D rbody;

    /// <summary>
    /// Public Rigidbody2D reference of a given (fired) laser
    /// </summary>
    public Rigidbody2D laser;

    /// <summary>
    /// Private float used for calculating the fire rate of the lasers
    /// </summary>
    private float fireRate = 0.5f;

    /// <summary>
    /// Private float used for tracking when next laser can be shot
    /// </summary>
    private float nextFire = -1f;

    /// <summary>
    /// Private reference to the AudioController script
    /// </summary>
    private AudioController audioController;

    /// <summary>
    /// Public AudioClip reference to the laser firing SFX
    /// </summary>
    public AudioClip laserFire;

    /// <summary>
    /// Private float that tracks remaining time with a given powerup
    /// </summary>
    private float powerupTimer = 0f;

    // Private bools used for tracking whether certain powerups have been picked-up
    private bool hasShotgun = false;
    private bool hasMinigun = false;

    /// <summary>
    /// Public GameObject reference to the timer UI (elements)
    /// </summary>
    public GameObject timerUI;

    /// <summary>
    /// Private Text reference to the timer UI text
    /// </summary>
    private Text timerText;


    void Start()
    {
        // Initialise timerText, rbody, and audioController
        timerText = timerUI.GetComponent<Text>();
        rbody = GetComponent<Rigidbody2D>();
        audioController = GameObject.Find("Audio Controller").GetComponent<AudioController>();
    }

    void Update()
    {
        // Update the timer text with the remaining powerup time
        timerText.text = "Powerup Time Remaining: " + powerupTimer.ToString("#.00");

        // If Spacebar pressed, call OnShoot() to fire a laser
        if (Keyboard.current.spaceKey.isPressed)
            OnShoot();

        // If player currently has a powerup, decrement the powerup timer
        if (hasShotgun == true || hasMinigun == true)
            powerupTimer -= Time.deltaTime;

        // If the powerup time has expired, disable all powerups and reset everything related to powerups
        if (powerupTimer <= 0)
        {
            hasShotgun = false;
            hasMinigun = false;
            timerUI.SetActive(false);
            powerupTimer = 6;
        }

    }

    void FixedUpdate()
    {
        // Set the velocity to be in the appropriate direction at the given movement speed
        rbody.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }

    /// <summary>
    /// Public method that continually updates moveDirection
    /// </summary>
    /// <param name="inputValue">Inputvalue to be read</param>
    public void OnMove(InputValue inputValue)
    {
        moveDirection = inputValue.Get<Vector2>();
    }

    /// <summary>
    /// Public method that fires lasers, including factoring in powerups 
    /// </summary>
    public void OnShoot()
    {
        // If the next laser can be fired
        if (Time.time > nextFire)
        {
            // Increment nextFire by fireRate
            nextFire = Time.time + fireRate;

            // If player has minigun powerup, change fireRate to simulate minigun functionality, then fire laser
            if (hasMinigun == true)
            {
                fireRate = 0.1f;
                Rigidbody2D laserClone;
                laserClone = Instantiate(laser, new Vector2(transform.position.x, transform.position.y + 2), transform.rotation);
            }

            // Else if player has shotgun, fire 3 lasers simultaneously in a shotgun-angle
            else if (hasShotgun == true)
            {

                Rigidbody2D laserClone1 = Instantiate(laser, new Vector2(transform.position.x, transform.position.y + 2), transform.rotation);
                Rigidbody2D laserClone2 = Instantiate(laser, new Vector2(transform.position.x, transform.position.y + 2), transform.rotation);
                Rigidbody2D laserClone3 = Instantiate(laser, new Vector2(transform.position.x, transform.position.y + 2), transform.rotation);

                laserClone1.transform.Rotate(0, 0, 30);
                laserClone2.transform.Rotate(0, 0, 0);
                laserClone3.transform.Rotate(0, 0, -30);

            }

            // Otherwise if the player has no powerups, simply fire a laser (with the normal firerate)
            else
            {
                fireRate = 0.5f;
                Rigidbody2D laserClone;
                laserClone = Instantiate(laser, new Vector2(transform.position.x, transform.position.y + 2), transform.rotation);
            }

            // Play the laser firing SFX 
            audioController.GetComponent<AudioSource>().PlayOneShot(laserFire, AudioController.audioVolume);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player picked up the shotgun powerup, enable shotgun functionality
        if (collision.gameObject.name == "Shotgun(Clone)")
        {
            powerupTimer = 6f;
            hasShotgun = true;
            Destroy(collision.gameObject);
            SpawnPowerups.numOfPowerups--;
            timerUI.SetActive(true);
        }

        // Else if player picked up minigun powerup, enable minigun functionality
        else if (collision.gameObject.name == "Minigun(Clone)")
        {
            powerupTimer = 6f;
            hasMinigun= true;
            Destroy(collision.gameObject);
            SpawnPowerups.numOfPowerups--;
            timerUI.SetActive(true);
        }
    }

}





