using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that controls the behaviour of the exit button
/// </summary>
public class ExitButton : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }
}
