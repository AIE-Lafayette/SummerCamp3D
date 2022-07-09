using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour
{
    /// <summary>
    /// A reference to our UI manager to make the win and lose screens appear.
    /// </summary>
    public UIManagerBehaviour UIManager;
    /// <summary>
    /// Stores a reference to the one and only win box in the scene.
    /// </summary>
    public WinBoxBehaviour WinBox;
    /// <summary>
    /// Stores a reference to the player so we can stop their movement when they win.
    /// </summary>
    public PlayerMoveBehaviour Player;
    
    // Update is called once per frame
    void Update()
    {
        //If the player won display the win screen.
        if (WinBox.HasWon)
        {
           UIManager.FadeInLevelCompleteScreen();
            Player.CanMove = false;
        }
        //If the player lost display the lose screen.
        else if (!Player.gameObject.activeSelf)
        {
            UIManager.FadeInLevelFailScreen();
            Player.CanMove = false;
        }

    }
}
