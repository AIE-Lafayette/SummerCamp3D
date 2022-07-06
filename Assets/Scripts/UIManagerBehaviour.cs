using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerBehaviour : MonoBehaviour
{
    public CanvasGroup GameOverPanel;
    public Image BackgroundImage;
    public Text StartInstructionsTextBox;
    public Text WinTextBox;
    public Text LoseTextBox;
    public Text ScoreTextBox;
    public Text CountDownTextBox;
    public float FadeInSpeed;

    private bool _startFade;

    public void FadeInLevelCompleteScreen()
    {
        BackgroundImage.color = Color.white;
        WinTextBox.gameObject.SetActive(true);
        _startFade = true;
    }
    
    public void FadeInLevelFailScreen()
    {
        BackgroundImage.color = Color.black;
        LoseTextBox.gameObject.SetActive(true);
        _startFade = true;
    }

    public void FadeInEndScreen()
    {
        BackgroundImage.color = Color.white;
        WinTextBox.gameObject.SetActive(true);
        WinTextBox.text = "Thanks for Playing! \n Press Esc To Quit";
        _startFade = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!_startFade || GameOverPanel.alpha >= 1)
            return;

        GameOverPanel.alpha += Time.deltaTime * FadeInSpeed;
    }
}
