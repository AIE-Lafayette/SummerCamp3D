using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextBehaviour : MonoBehaviour
{
    //Stores a reference to our player to access the score value.
    public PlayerMoveBehaviour Player;

    //Stores a reference to the text component attached to the game object.
    private Text _text;
    
    // Start is called before the first frame update
    void Start()
    {
        //Gets the text component attached to this game object to we can update it.
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Makes the text box display the players current score.
        _text.text = "Score: " + Player.Score;
    }
}
