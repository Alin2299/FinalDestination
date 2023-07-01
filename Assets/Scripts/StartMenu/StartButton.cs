using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script that controls the behaviour of the start button
/// </summary>
public class StartButton : MonoBehaviour
{

    public void NextScene()
    {
        SceneManager.LoadScene("Main");
    }

}
