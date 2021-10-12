using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Dialogue dialogue;
    public QuestCompleted newQuesttext;
    public float TalkRange;
    public LayerMask WhatIsPlayer;
    public bool playerTalkRange;
    public NavMeshAgent agent;
    public Transform player;
    public Animator Anti;
    public QuestGiver complete;
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        agent.SetDestination(transform.position);
        Update();
        void Update()
        {
            Vector3 lookVector = player.transform.position - transform.position;
            lookVector.y = transform.position.y;
            Quaternion rot = Quaternion.LookRotation(lookVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
            if(complete.QuestCompleted)
            {
                FindObjectOfType<DialogueManager>().QuestCompleted(newQuesttext);
            }
        }
    }
    private void Update()
    {
        //Checks for player in talk ranged
        playerTalkRange = Physics.CheckSphere(transform.position, TalkRange, WhatIsPlayer);

        if (playerTalkRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
            //Anti.SetTrigger("Talking");
            Anti.SetBool("Talkingtrue", true);
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            GetComponent<WaypointNav>().enabled = false;
        }
        else if (!playerTalkRange)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
            GetComponent<WaypointNav>().enabled = true;
            FindObjectOfType<DialogueManager>().EndDialogue();
            Anti.SetTrigger("NotTalking");
            Anti.SetBool("Talkingtrue", false);
        }
        else if(!playerTalkRange && complete.QuestCompleted)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
            GetComponent<WaypointNav>().enabled = true;
            Anti.SetTrigger("NotTalking");
            Anti.SetBool("Talkingtrue", false);
        }
    }
}
