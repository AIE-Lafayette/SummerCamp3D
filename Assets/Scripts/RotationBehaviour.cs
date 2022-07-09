using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBehaviour : MonoBehaviour
{
    /// <summary>
    /// Controls how fast this game object will rotate.
    /// </summary>
    public float RotationSpeed;

    private void Update()
    {
        //Repeatedly rotates the object based on the rotation speed.
        transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime, Space.World);
    }
}
