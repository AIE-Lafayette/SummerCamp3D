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
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        
        if (Input.GetKeyDown(KeyCode.W))
            _moveBehaviour.Jump();
        
        _moveBehaviour.SetMoveDirection(moveDirection);
    }
}
