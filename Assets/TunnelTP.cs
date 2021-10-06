using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TunnelTP : MonoBehaviour
{
        public Animator Transition;
        public float TransitionTime = 3f;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(Loadworld(4));
                IEnumerator Loadworld(int levelIndex)
                {

                    yield return new WaitForSeconds(TransitionTime);

                    SceneManager.LoadScene(levelIndex);
                }
            }
        }
    }
