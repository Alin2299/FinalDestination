using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;
using UnityEngine.InputSystem;

/// <summary>
/// Script that controls the metagame such as: winning/losing, updating score, playing music, etc
/// </summary>
public class GameController : MonoBehaviour
{
    /// <summary>
    /// Public GameObject representing the player's ship
    /// </summary>
    public GameObject playerShip;

    /// <summary>
    /// Public GameObject representing the game over/end text object
    /// </summary>
    public GameObject EndText;

    /// <summary>
    /// Public GameObject representing the score text object
    /// </summary>
    public GameObject ScoreText;

    /// <summary>
    /// Private reference to the music controller script
    /// </summary>
    private MusicController musicController;

    /// <summary>
    /// Private static int that represents the current score (of the player)
    /// </summary>
    [SerializeField]
    private static int score;

    /// <summary>
    /// Private Text that represents the actual score text
    /// </summary>
    private Text scoreText;


    void Start()
    {
        // Initialise musicController and scoreText, and disable the end text
        musicController = GameObject.Find("Music Controller").GetComponent<MusicController>();
        scoreText = ScoreText.GetComponent<Text>();
        EndText.SetActive(false);
    }


    void Update()
    {
        // If the player ship has been destroyed, stop the game and show the end/game over text
        if (playerShip == null)
        {
            Time.timeScale = 0;
            EndText.SetActive(true);

            musicController.StopMusic();

            // If the Enter key is pressed, start a new game (by resetting everything)
            if (Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame)
            {
                Scene Main = SceneManager.GetActiveScene();
                SceneManager.LoadScene(Main.name);
                Time.timeScale = 1;
                score = 0;
                EndText.SetActive(false);
            }
        }

        // Update the score text with the current score
        scoreText.text = "Score: " + score;
    }

    /// <summary>
    /// Public method that increases the score by a certain amount
    /// </summary>
    /// <param name="scoreToBeAdded">Amount that the score should be increased by</param>
    public void AddScore(int scoreToBeAdded)
    {
        score += scoreToBeAdded;
    }
}
