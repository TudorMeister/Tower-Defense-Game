using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

   public GameObject canvas;
   public void PlayGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("LevelSelect");
    }

    public void QuitGame()
    {
        Time.timeScale = 1.0f;
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        canvas.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
