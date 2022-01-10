using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text ScoreText,ExitText,RestartText,ContinueText, LoseText;
    public Button ExitButton, RestartButton, ContinueButton;
    private float UpdateDelta = 0;
    
    void Update()
    {
        UpdateDelta += Time.deltaTime;
        if (UpdateDelta >= 1f)
        {
            Data.Score++;
            UpdateDelta = 0f;
        }
        
        ScoreText.text = "Score: " + Data.Score;
    }
   
    public void LoseGame()
    {
        ManagerMenu(true);
        Time.timeScale = 0;
    }

    public void ManagerMenu(bool flag)
    {
        LoseText.enabled = flag;
        ExitText.enabled = flag;
        RestartText.enabled = flag;
        ContinueText.enabled = flag;
        ExitButton.image.enabled = flag;
        RestartButton.image.enabled = flag;
        ContinueButton.image.enabled = flag;
        ExitButton.enabled = flag;
        RestartButton.enabled = flag;
        ContinueButton.enabled = flag;


    }

}
