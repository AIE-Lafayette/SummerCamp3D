using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerBehaviour : MonoBehaviour
{
    /// <summary>
    /// We'll use the canvas group component to adjust transparency for multiple objects.
    /// </summary>
    public CanvasGroup GameOverPanel;
    /// <summary>
    /// We can use this variable to change the color of the background based on whether or not the player won.
    /// </summary>
    public Image BackgroundImage;
    /// <summary>
    /// A reference to the win textbox will allow us to turn it on if our player won.
    /// </summary>
    public Text WinTextBox;
    /// <summary>
    /// A reference to the win textbox will allow us to turn it on if our player failed.
    /// </summary>
    public Text LoseTextBox;
    /// <summary>
    /// This will control how fast our UI elements fade in and out.
    /// </summary>
    public float FadeInSpeed;
    /// <summary>
    /// We can use this value to keep track of wether or not the UI has started fading in or out.
    /// </summary>
    private bool _fadeEnabled;
    /// <summary>
    /// This will display the amount of seconds the player has before the game starts.
    /// </summary>
    public Text CountDownTextBox;
    /// <summary>
    /// We'll need to store the start instructions textbox so we can easily turn it off when the timer is up.
    /// </summary>
    public Text StartInstructionsTextBox;
    /// <summary>
    /// A reference to the win textbox will allow us to turn it on if our player beat the game.
    /// </summary>
    public Text EndTextBox;



    /// <summary>
    /// This function will be called by the game manager to start fading in the win screen.
    /// </summary>
    public void FadeInLevelCompleteScreen()
    {
        //We change the color of the background to fit our win screen better.
        BackgroundImage.color = Color.white;
        //The win text is enabled to let the player know they've won.
        WinTextBox.gameObject.SetActive(true);
        //Activate the fade logic.
        _fadeEnabled = true;
    }

    /// <summary>
    /// This function will be called by the game manager to start fading in the lose screen.
    /// </summary>
    public void FadeInLevelFailScreen()
    {
        //We change the color of the background to fit our lose screen better.
        BackgroundImage.color = Color.black;
        //The lose text is enabled to let the player know they've lost.
        LoseTextBox.gameObject.SetActive(true);
        //Activate the fade logic.
        _fadeEnabled = true;
    }

    /// <summary>
    /// This function will be called by the game manager to start fading in the win screen.
    /// </summary>
    public void FadeInEndScreen()
    {
        //We change the color of the background to fit our  screen better.
        BackgroundImage.color = Color.white;
        //The win text is enabled to let the player know they've won.
        EndTextBox.gameObject.SetActive(true);
        _fadeEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //If the fade toggle is off or if the game over panel is fully opaque leave this function.
        if (_fadeEnabled == false || GameOverPanel.alpha >= 1)
        {
            return;
        }

        //Slowly increase the opacity of the background using the speed variable.
        GameOverPanel.alpha += Time.deltaTime * FadeInSpeed;
    }
}
