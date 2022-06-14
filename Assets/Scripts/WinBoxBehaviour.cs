using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBoxBehaviour : MonoBehaviour
{
    [SerializeField] private bool _hasWon;
    
    public bool HasWon
    {
        get => _hasWon;
        set => _hasWon = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        _hasWon = true;
    }
}
