using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelMusicTrig : MonoBehaviour
{
    public float num;
    public GameObject castle;
    public AudioSource tunnmus;
    public AudioSource bossmus;
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            castle.SetActive(true);
            tunnmus.Play();
            bossmus.Stop();
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            castle.SetActive(false);
           tunnmus.Stop();
            bossmus.Play();
        }
    }
}

