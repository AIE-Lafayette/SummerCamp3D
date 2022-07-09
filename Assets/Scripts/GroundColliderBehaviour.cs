using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColliderBehaviour : MonoBehaviour
{
    /// <summary>
    /// This value will bw used to keep track of whether or not the collider is touching the ground.
    /// </summary>
    public bool IsGrounded;

    /// <summary>
    /// This function is called whenever this game object enters a trigger volume.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        //The grounded variable will be set to true if the object collided with has the Floor tag.
        if (other.CompareTag("Floor"))
            IsGrounded = true;
    }

    /// <summary>
    /// This function is called whenever this game object leaves a trigger volume.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        //The grounded variable will be set to false if the other object has the Floor tag.
        if (other.CompareTag("Floor"))
            IsGrounded = false;
    }
}
