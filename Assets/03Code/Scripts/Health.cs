using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public static int health;
    public GameObject Heart1, Heart2, Heart3, Heart4;
    private void Start()
    {
        health = 4;
        Heart1.gameObject.SetActive(true);
        Heart2.gameObject.SetActive(true);
        Heart3.gameObject.SetActive(true);
        Heart4.gameObject.SetActive(true);

    }
    public void Update()
    {
        if (health > 4)
            health = 4;
        //if (health == 4)
        //{
        //    Heart1.gameObject.SetActive(true);
        //    Heart2.gameObject.SetActive(true);
        //    Heart3.gameObject.SetActive(true);
        //    Heart4.gameObject.SetActive(true);
        //}
        //else if(health == 3)
        //    {
        //    Heart1.gameObject.SetActive(true);
        //    Heart2.gameObject.SetActive(true);
        //    Heart3.gameObject.SetActive(true);
        //    Heart4.gameObject.SetActive(false);
        //}
        //else if (health == 2)
        //{
        //    Heart1.gameObject.SetActive(true);
        //    Heart2.gameObject.SetActive(true);
        //    Heart3.gameObject.SetActive(false);
        //    Heart4.gameObject.SetActive(false);
        //}
        //else if (health == 1)
        //{
        //    Heart1.gameObject.SetActive(true);
        //    Heart2.gameObject.SetActive(false);
        //    Heart3.gameObject.SetActive(false);
        //    Heart4.gameObject.SetActive(false);
        //}
        //else if (health == 0)
        //{
        //    Heart1.gameObject.SetActive(false);
        //    Heart2.gameObject.SetActive(false);
        //    Heart3.gameObject.SetActive(false);
        //    Heart4.gameObject.SetActive(false);
        //    // GameOverUI.SetActive(true);
        //    // Time.timeScale = 0f;
        //    GameObject.FindWithTag("UI").GetComponent<UIScript>().GameOver();
        //}
        switch (health)
        {
            case 4:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                Heart4.gameObject.SetActive(true);
                break;
            case 3:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                Heart4.gameObject.SetActive(false);
                break;
            case 2:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(false);
                Heart4.gameObject.SetActive(false);
                break;
            case 1:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                Heart4.gameObject.SetActive(false);
                break;
            case 0:
                Heart1.gameObject.SetActive(false);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                Heart4.gameObject.SetActive(false);
                break;
        }
        if (health <= 0)
        {
            GameObject.Find("UI").GetComponent<UIScript>().GameOver();
        }

    }
}
