using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointNav : MonoBehaviour
{
    public Transform[] wayPoints;
    private int nextwayPoint = 0;
    private NavMeshAgent agent;
    //public GameObject waypoint2;
    [Range(0f, 5f)]
    public float width = 1f;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
       agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (wayPoints.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = wayPoints[nextwayPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
       nextwayPoint  = (nextwayPoint + 1) % wayPoints.Length;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
//        Transform destinationPoint = (waypoint2);
//gameObject.GetComponent<NavMeshAgent>().Stop();
    }
}
































//public NavMeshAgent agent;
//public Waypoint currentWaypoint;
//private void Awake()
//{
//    agent = GetComponent<NavMeshAgent>();

//}
//void Start()
//{
//    agent.destination = currentWaypoint.GetPostion();
//}
//private void Update()
//{
//    //Anti.SetTrigger("Search");
//    if (!agent.pathPending)
//    {

//        if (agent.remainingDistance <= agent.stoppingDistance)
//        {
//            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
//            {
//                currentWaypoint = currentWaypoint.nextWaypoint;
//                agent.destination = currentWaypoint.GetPostion();
//            }
//        }
//    }
//}
//}