using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class jumpHit : MonoBehaviour
{
    public int coin = 0;
    public TMP_Text coinAmount;
    public TMP_Text questTracker;
    public TMP_Text questType;
    public Quest quest;
    public DialogueManager dialogue;
    public QuestGiver next;
    public GameObject player;
    public Transform attackPoint;
    public bool grounded;
    public bool HitEnemy = false;

    public float attackRange = 0.2f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask enemyLayers, Ground;
    public int attackDamage = 1;
    public float attackrate = 2f;
    float nextAttacktime = 0f;
    private EnemyHealth Slimes;


    public void Start()
    {
        questTracker.gameObject.SetActive(false);
        questType.gameObject.SetActive(false);
    }
    void Update()
    {
        coinAmount.text = coin.ToString();
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, Ground);
        if (Time.time >= nextAttacktime)
        { 
        if (grounded == false)
        {
            Attack();
                nextAttacktime = Time.time + 1f / attackrate;
        }
            if (quest.isActive)
            {
                questTracker.text = quest.goal.currentAmount.ToString();
                questType.text = quest.questAmount;
                questTracker.gameObject.SetActive(true);
                questType.gameObject.SetActive(true);
                if (quest.goal.IsReached())
                {
                    quest.Complete();
                    next.NextPart();
                }
                if(quest.isActive == false)
                {
                    questTracker.gameObject.SetActive(false);
                    questType.gameObject.SetActive(false);
                }

            }
        }
    }
    public void CoinCollect()
    {
        if (dialogue.questsentences.Count == 0)
        {
            coin = quest.reward;
        }
    }
    public void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        OnColliderEnter();
        void OnColliderEnter()
        {
            foreach (Collider enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyHealth>().takeDamage(attackDamage);
                //quest.goal.EnemyKilled();
               // HitEnemy = true;
                //Debug.Log("We hit " + enemy.name);
                OnColliderExit(enemy);
            }
            
            
        }
       void OnColliderExit(Collider hit)
        { 
            if(hit.CompareTag("Slime") && quest.isActive)

            quest.goal.RevengeOfTheSlimes();
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
