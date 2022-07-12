using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehaviour : MonoBehaviour
{
    /// <summary>
    /// This variable is used to store a reference to the player's move script 
    /// so we can update the move direction.
    /// </summary>
    private PlayerMoveBehaviour _moveBehaviour;

    /// <summary>
    /// This variable stores a reference to the game manager
    /// so that we can tell when to start its timer.
    /// </summary>
    public GameManagerBehaviour GameManager;

    // Update is called once per frame
    private void Awake()
    {
        //Searches the game object this script is attached to to find the move script.
        _moveBehaviour = GetComponent<PlayerMoveBehaviour>();
    }

    void Update()
    {
        //Quits the application when the game is player outside of the editor.
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        //Starts the countdown if the player presses any key.
        if (Input.anyKeyDown)
            GameManager.StartTimerEnabled = true;
        
        //The player is told to jump if the W key is pressed.
        if (Input.GetKeyDown(KeyCode.W))
            _moveBehaviour.Jump();

        //We can change the move direction based on the button that was pressed.
        if (Input.GetKey(KeyCode.A))
            _moveBehaviour.MoveDirection = Vector3.left;
        else if (Input.GetKey(KeyCode.D))
            _moveBehaviour.MoveDirection = Vector3.right;
        else
            _moveBehaviour.MoveDirection = Vector3.zero;

    }
}
