using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject HealthBar;
    public static bool GamePause = false;
    public Animator Transition;
    public float TransitionTime = 3f;

    public void retry()
    {
        GamePause = false;
        GameOverUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        GamePause = false;
        Time.timeScale = 1f;
    }
    public void GameOverUi()
    {
        GamePause = true;
        GameOverUI.SetActive(true);
        HealthBar.SetActive(false);
        GamePause = true;
        Time.timeScale = 0f;
    }
    public void LoadLevelHub()
    {
        StartCoroutine(LoadLevel(1));
        IEnumerator LoadLevel(int levelIndex)
        {
            Transition.SetTrigger("Start");

            yield return new WaitForSeconds(TransitionTime);

            SceneManager.LoadScene(levelIndex);

        }
    }
    public void LoadLevelMainMenu()
    {
        StartCoroutine(LoadLevel(0));
        IEnumerator LoadLevel(int levelIndex)
        {
            Transition.SetTrigger("Start");

            yield return new WaitForSeconds(TransitionTime);

            SceneManager.LoadScene(levelIndex);
        }
    }
}
