using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Animator Transition;
    public float TransitionTime = 3f;
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
}
