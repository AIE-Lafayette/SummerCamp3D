using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveBehaviour : MonoBehaviour
{
    private Rigidbody _rigidBody;
    public float MoveSpeed;
    public int Score;
    private Vector3 _moveDirection;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GroundColliderBehaviour _groundCollider;
    [SerializeField] private float _airSpeedScale;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        if (_groundCollider.IsGrounded)
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    public void SetMoveDirection(Vector3 moveDirection)
    {
        _moveDirection = new Vector3(moveDirection.x, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            Score++;
        }
    }

    void FixedUpdate()
    {
        if (!_groundCollider.IsGrounded)
            _moveDirection /= _airSpeedScale;
        
        transform.position += _moveDirection * (MoveSpeed * Time.fixedDeltaTime);
        
        Debug.Log(Score);
    }
}
