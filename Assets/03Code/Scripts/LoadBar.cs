using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadBar : MonoBehaviour
{
    public  GameObject loadingScreen;
    public  Slider slider;
    public class LevelLoader : MonoBehaviour
    {
        public void LoadLevel1(int sceneIndex)
        {
            StartCoroutine(LoadAsync(sceneIndex));
        }
        //code for progress bar
        IEnumerator LoadAsync(int sceneIndex)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

           // loadingScreen.SetActive(true);

            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);

                //slider.value = progress;

                yield return null;
            }
        }
    }
}
