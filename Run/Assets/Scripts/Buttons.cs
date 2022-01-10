using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class Buttons : MonoBehaviour
{
    public GameManager _gameManager;
    public void Restart()
    {
        SceneManager.LoadScene("Main");
        Data.Score = 0;
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void Continue()
    {
        _gameManager.ManagerMenu(false);
        Time.timeScale = 1;
    }
}
