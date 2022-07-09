using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBoxBehaviour : MonoBehaviour
{
    /// <summary>
    /// This value stores whether or not the player has won. 
    /// It will be used to update UI, and stop player movement.
    /// </summary>
    public bool HasWon;

    private void OnTriggerEnter(Collider other)
    {
        //If the winbox collided with the player they've won!
        if (other.CompareTag("Player"))
        {
            HasWon = true;
        }
    }
}
