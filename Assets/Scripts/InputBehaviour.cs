using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehaviour : MonoBehaviour
{
    private PlayerMoveBehaviour _moveBehaviour;

    // Update is called once per frame
    private void Awake()
    {
        _moveBehaviour = GetComponent<PlayerMoveBehaviour>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        
        if (Input.anyKeyDown)
            GameManagerBehaviour.StartTimerEnabled = true;
        
        if (Input.GetKeyDown(KeyCode.W))
            _moveBehaviour.Jump();

        if (Input.GetKey(KeyCode.A))
            _moveBehaviour.SetMoveDirection(Vector3.left);
        else if (Input.GetKey(KeyCode.D))
            _moveBehaviour.SetMoveDirection(Vector3.right);
        else
            _moveBehaviour.SetMoveDirection(Vector3.zero);
        
    }
}
