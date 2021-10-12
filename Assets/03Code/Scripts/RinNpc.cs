using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinNpc : MonoBehaviour
{
    [SerializeField] private Animator Bow;

    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Player"))
        {
            Bow.SetBool("Bow", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Bow.SetBool("Bow", false);
        }
    }
}
