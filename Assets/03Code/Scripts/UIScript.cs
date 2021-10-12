using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public static bool GamePause = false;
    public GameObject PauseMenuUI;
    public GameObject OptionsMenu;
    public GameObject HealthBar;
    public GameObject GameOverUI;
    public GameObject QuestLog;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (GamePause)
            {
                Resume();
            }
            else
            {
                Pause();
                Questlog();

            }
        }


    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        OptionsMenu.SetActive(false);
        QuestLog.SetActive(false);
        HealthBar.SetActive(true);
        Time.timeScale = 1f;
        GamePause = false;
    }
    public void retry()
    {
       GameOverUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
        HealthBar.SetActive(false);
    }
    public void Exit()
    {
        Debug.Log("Quitting Game!");
        Application.Quit();
    }
   public void GameOver()
    {
       GameOverUI.SetActive(true);
        HealthBar.SetActive(false);
        GamePause = true;
        Time.timeScale = 0f;
    }
    public void Questlog()
    {
        QuestLog.SetActive(true);
        GamePause = true;
        Time.timeScale = 0f;
    }
   }
