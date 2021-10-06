using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollower : MonoBehaviour
{
    public GameObject ThePlayer;
    public float Targetdistance;
    public float AllowedDistance = 5f;
    public GameObject TheNpc;
    public float Followspeed;
    public RaycastHit Shot;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(ThePlayer.transform);
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out Shot))
        {
            Targetdistance = Shot.distance;
            if (Targetdistance >= AllowedDistance)
            {
                Followspeed = 0.2f;
                TheNpc.GetComponent<Animator>().Play("Fly Forward");
                transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, Followspeed);
            }
            /*else
            {
                Followspeed = 0;
                TheNpc.GetComponent<Animator>().Play("Land");
                //Animator.Stop();
                //TheNpc.GetComponent<Animator>().Play("Idle02");
            }*/
            
        }
    }
}
