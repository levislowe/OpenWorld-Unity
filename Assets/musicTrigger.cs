using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicTrigger : MonoBehaviour
{
    public float num;
    public GameObject castle;
    public AudioSource Castlemus;
    public AudioSource townmus;
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            castle.SetActive(true);
            Castlemus.Play();
            townmus.Stop();
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            castle.SetActive(false);
           Castlemus.Stop();
            townmus.Play();
        }
    }
}
