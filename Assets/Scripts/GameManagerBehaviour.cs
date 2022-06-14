using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _winText;

    [SerializeField] private GameObject _loseText;
    [SerializeField] private WinBoxBehaviour _winBox;

    [SerializeField] private GameObject _player;
    [SerializeField] private ObstacleCourseMovementBehaviour _courseMovementBehaviour;
    
    // Update is called once per frame
    void Update()
    {
        if (_winBox.HasWon)
            _winText.SetActive(true);
        else if (!_player.activeSelf)
            _loseText.SetActive(true);
        else return;
        
        _courseMovementBehaviour.CanMove = false;

    }
}
