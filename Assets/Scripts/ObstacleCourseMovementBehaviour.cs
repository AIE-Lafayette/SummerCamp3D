using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCourseMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    public bool CanMove = true;
    
    // Update is called once per frame
    void Update()
    {
        if (CanMove)
            transform.position += Vector3.back * (_moveSpeed * Time.deltaTime);
    }
}
