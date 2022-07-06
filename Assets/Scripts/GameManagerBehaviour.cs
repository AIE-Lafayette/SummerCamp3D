using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour
{
    public static int CurrentLevel;
    public static bool StartTimerEnabled;
    public static int MaxLevel = 2;
    public UIManagerBehaviour UIManager;
    public WinBoxBehaviour WinBox;
    public PlayerMoveBehaviour Player;
    public ObstacleCourseMovementBehaviour CourseMovementBehaviour;
    public float StartTimer;
    public float DeathLoadTime;
    public float LevelLoadTime;
    public bool GameStarted;
    public bool GameOver;

    private void Awake()
    {
        StartTimerEnabled = false;
        GameStarted = false;
    }

    public IEnumerator LoadLevel(int levelIndex, float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(levelIndex);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (StartTimerEnabled == true && GameStarted == false)
        {
            UIManager.StartInstructionsTextBox.gameObject.SetActive(false);
            UIManager.CountDownTextBox.gameObject.SetActive(true);
            StartTimer -= Time.deltaTime;
            UIManager.CountDownTextBox.text = Mathf.CeilToInt(StartTimer).ToString();
            
            if (StartTimer <= 0)
            {
                StartTimerEnabled = false;
                GameStarted = true;
                CourseMovementBehaviour.CanMove = true;
                Player.CanMove = true;
                UIManager.CountDownTextBox.gameObject.SetActive(false);
            }

            return;
        }

        if (WinBox.HasWon && GameOver == false)
        {
            CurrentLevel++;
            GameOver = true;

            if (CurrentLevel < MaxLevel)
            {
                StartCoroutine(LoadLevel(CurrentLevel, LevelLoadTime));
                UIManager.FadeInLevelCompleteScreen();
            }
            else
                UIManager.FadeInEndScreen();
        }
        else if (!Player.gameObject.activeSelf && GameOver == false)
        {
            UIManager.FadeInLevelFailScreen();
            StartCoroutine(LoadLevel(CurrentLevel, DeathLoadTime));
            GameOver = true;
        }
        else return;
        
        CourseMovementBehaviour.CanMove = false;

    }
}
