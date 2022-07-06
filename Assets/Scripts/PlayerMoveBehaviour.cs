using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class PlayerMoveBehaviour : MonoBehaviour
{
    public bool CanMove;
    public float MoveSpeed;
    public int Score;
    public GameObject Explosion;
    private Rigidbody _rigidBody;
    private Vector3 _velocity;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GroundColliderBehaviour _groundCollider;
    [SerializeField] private float _airSpeedScale;
    [SerializeField] private float _xMin;
    [SerializeField] private float _xMax;

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
        _velocity = moveDirection * (MoveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            Score++;
        }
        else if (other.CompareTag("Obstacle"))
        {
            gameObject.SetActive(false);
            Instantiate(Explosion, transform.position, transform.rotation);
        }
    }

    void FixedUpdate()
    {
        if (!CanMove)
            return;
        
        if (!_groundCollider.IsGrounded)
            _velocity /= _airSpeedScale;
        
        Vector3 newPosition = transform.position + _velocity;
        newPosition.x = Mathf.Clamp(newPosition.x, _xMin, _xMax);

        transform.position = newPosition;
    }
}
