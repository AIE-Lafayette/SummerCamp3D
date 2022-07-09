using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementBehaviour : MonoBehaviour
{
    /// <summary>
    /// A reference to the player is stored so that we may track its position.
    /// </summary>
    public Transform Player;

    /// <summary>
    /// This will store how far away the camera will stay behind the player.
    /// </summary>
    private float _offset;
    
    // Start is called before the first frame update
    void Start()
    {
        //When the game starts, we'll store the current distance between the camera and the player so we can stay at that distance.
        _offset = Player.position.z - transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //We can subtract the distance found earlier from the players current position to get where the camera should be.
        float newZ = Player.position.z - _offset;
        //We set the camera's position to the new position found.
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
    }
}
