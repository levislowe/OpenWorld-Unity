using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator Anti;
    public int Maxhealth = 1;
    int currentHealth;
    public bool dead;
    public BoxCollider Body;
    public BoxCollider Head;
    public ParticleSystem deadSmoke;
    public GameObject corps;
    public Quest quest;
    public bool queston = false;
    // Start is called before the first frame update
    private void Update()
    {
        if (currentHealth <= 0)
        {
            dead = true;
            GetComponent<EnemyAi>().enabled = false;
            Die();
        }
        if (Anti.GetBool("Dead?"))
        {
            //Anti.SetBool("Dead?", true);
            //Anti.Play("Die");
            agent.SetDestination(transform.position);
        }
        if (Anti.GetCurrentAnimatorStateInfo(0).IsTag("Dead"))
        {
            StartCoroutine(Dead());
        }
    }
    void Start()
    {
        dead = false;
        currentHealth = Maxhealth;
        deadSmoke.Stop();
    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        Anti.SetTrigger("Hurt");
    }
    public void Die()
    {
        Debug.Log("Enemy Died!");
        Anti.SetBool("Dead?", true);
        deadSmoke.Play();

    }
    IEnumerator Dead()
   {
        yield return new WaitForSeconds(1f);
        GetComponent<Animator>().enabled = false;
        Head.enabled = false;
        Body.enabled = false;
       // GetComponent<EnemyAi>().enabled = false;
        this.enabled = false;
        corps.SetActive(false);
    }
   // public void Questactive()
   // {
    //    if(queston)
       // {
           // quest.goal.currentAmount++;
      //  }
  //  }


}
