using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class PlayerMoveBehaviour : MonoBehaviour
{
    /// <summary>
    /// This value will control how fast our player can move forward.
    /// We can use this to tweak the difficulty of our game.
    /// </summary>
    public float ForwardMoveSpeed;
    /// <summary>
    /// This value will control how fast our player can move side to side.
    /// We can use this to tweak the feel and responsiveness of our game.
    /// </summary>
    public float HorizontalMoveSpeed;
    /// <summary>
    /// This value will store the total speed and direction of travel for our player.
    /// This is the value we'll add to position to move the player character.
    /// </summary>
    public Vector3 MoveDirection;
    /// <summary>
    /// This value will store how far to the left our player is allowed to travel.
    /// This is useful so that our player doesn't accidentally fall off stage.
    /// </summary>
    public float XMin;
    /// <summary>
    /// This value will store how far to the right our player is allowed to travel.
    /// This is useful so that our player doesn't accidentally fall off stage.
    /// </summary>
    public float XMax;
    /// <summary>
    /// This value will control how high our player will jump.
    /// </summary>
    public float JumpForce;
    /// <summary>
    /// This value will store a reference to the physics component thats attached to the player.
    /// </summary>
    private Rigidbody _rigidBody;
    /// <summary>
    /// This value will store a reference to the ground collider that is attached to this object.
    /// </summary>
    public GroundColliderBehaviour GroundCollider;
    /// <summary>
    /// This will be used to disable movement when the player wins.
    /// </summary>
    public bool CanMove;
    /// <summary>
    /// Keeps track of the amount of collectibles the player has gotten.
    /// </summary>
    public int Score;
    /// <summary>
    /// This value will store how much the movement speed will be reduced in air.
    /// </summary>
    public float AirSpeedScale;
    /// <summary>
    /// The particle effect that will spawn when the player dies.
    /// </summary>
    public GameObject Explosion;

    private void Awake()
    {
        //Gets the rigidbody component thats attached to the player.
        _rigidBody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// This function will be called whenever the jump button is pressed, and will 
    /// apply a force directly upwards to our player.
    /// </summary>
    public void Jump()
    {
        //Adds an instant upward force to the player using the rigidbody if the player is on the ground.
        if (GroundCollider.IsGrounded)
            _rigidBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
    }

    /// <summary>
    /// This function is called whenever the player enter a collider that isn't solid.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //Turn off the player and spawn an explosion if they collide with an obstacle.
        if (other.CompareTag("Obstacle"))
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
        //Increase the total score if they collide with a collectible.
        else if (other.CompareTag("Collectible"))
        {
            //Makes the collectible disappear.
            Destroy(other.gameObject);
            Score = Score + 1;
        }
    }

    void FixedUpdate()
    {
        //Do nothing if the player can't move.
        if (CanMove == false)
        {
            return;
        }

        //The player should be moving forward constantly, so we'll store another value for forward velocity that uses the forward move speed. 
        Vector3 forwardVelocity = Vector3.forward * (ForwardMoveSpeed * Time.fixedDeltaTime);
        //We can take the move direction and multiply it by the horizontal speed to get the players horizontal velocity. 
        Vector3 horizontalVelocity = MoveDirection * (HorizontalMoveSpeed * Time.fixedDeltaTime);

        //If we're not grounded, reduce the horizontal move speed to remove snappy air movement.
        if (!GroundCollider.IsGrounded)
            horizontalVelocity /= AirSpeedScale;

        //Combine the horizontal and forward velocity and add it to the current position to get the new position.
        Vector3 newPosition = transform.position + horizontalVelocity + forwardVelocity;
        //Clamp the x position to prevent the player position
        newPosition.x = Mathf.Clamp(newPosition.x, XMin, XMax);

        transform.position = newPosition;
    }
}