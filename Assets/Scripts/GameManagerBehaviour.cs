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
    /// <summary>
    /// Keeps track of whether or not the countdown has started.
    /// </summary>
    public bool StartTimerEnabled;
    /// <summary>
    /// Keeps track of whether or not the countdown has ended and our game has started.
    /// </summary>
    public bool GameStarted;
    /// <summary>
    /// How long in seconds the game countdown will be.
    /// </summary>
    public float StartTimer;
    /// <summary>
    /// This will store how long we want the game to pause before restarting the level after death.
    /// </summary>
    public float DeathLoadTime;
    /// <summary>
    /// This will store whether or not the game has ended after a player has died or as won.
    /// </summary>
    public bool GameOver;
    /// <summary>
    /// This variable keeps track of the level we are on. 
    /// The static word is there to make sure this number stays the same when we change scenes.
    /// </summary>
    public static int CurrentLevel;
    /// <summary>
    /// This is how long the game will wait before loading in the next level.
    /// </summary>
    public float LevelLoadTime;

    private void Awake()
    {
        //The countdown shouldn't start until the player starts it, so we'll make it false by default.
        StartTimerEnabled = false;
        GameStarted = false;
        Player.CanMove = false;
    }

    /// <summary>
    /// Loads a level based on the level number after the time to load that level has passed.
    /// </summary>
    public IEnumerator LoadLevel(int levelNumber, float timeToLoadLevel)
    {
        yield return new WaitForSeconds(timeToLoadLevel);
        SceneManager.LoadScene(levelNumber);
    }

    // Update is called once per frame
    void Update()
    {
        //If the player has activated the countdown and the game hasn't started yet...
        if (StartTimerEnabled == true && GameStarted == false)
        {
            //...turn on the countdown textbox and start counting down.
            UIManager.StartInstructionsTextBox.gameObject.SetActive(false);
            UIManager.CountDownTextBox.gameObject.SetActive(true);
            StartTimer -= Time.deltaTime;
            UIManager.CountDownTextBox.text = Mathf.CeilToInt(StartTimer).ToString();
            
            //If the countdown has reached 0...
            if (StartTimer <= 0)
            {
                //...allow the player to move and start the game.
                StartTimerEnabled = false;
                GameStarted = true;
                Player.CanMove = true;
                UIManager.CountDownTextBox.gameObject.SetActive(false);
            }
            
            //Does nothing if the timer is still going.
            return;
        }
        
        //If the player won display the win screen.
        if (WinBox.HasWon && GameOver == false)
        {
            //Increases the level count and marks that the game has ended.
            CurrentLevel = CurrentLevel + 1;
            GameOver = true;
            Player.CanMove = false;

            //Loads up a new level if we aren't at the last level.
            if (CurrentLevel <= SceneManager.sceneCount)
            {
                StartCoroutine(LoadLevel(CurrentLevel, LevelLoadTime));
                UIManager.FadeInLevelCompleteScreen();
            }
            //Loads up the end screen if we are at the last level.
            else
            {
                UIManager.FadeInEndScreen();
            }
        }
        //If the player lost display the lose screen.
        else if (Player.gameObject.activeSelf == false && GameOver == false)
        {
            UIManager.FadeInLevelFailScreen();
            Player.CanMove = false;
            //Ends the game an restarts the level from the beginning.
            GameOver = true;
            StartCoroutine(LoadLevel(CurrentLevel, DeathLoadTime));
        }

    }
}
