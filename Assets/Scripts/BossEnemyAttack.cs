//Enemy Attack for Nightmare Wraith 
using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    Animator NightmareWraith_Animation;
    GameObject player;
    PlayerHealth playerHealth;
   // EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        // enemyHealth = GetComponent<EnemyHealth>();
        NightmareWraith_Animation = GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }




//    void Update()
//    {
//        timer += Time.deltaTime;
//
//        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
//        {
//            Attack();
//        }
//
//        if (playerHealth.currentHealth <= 0)
//        {
//            anim.SetTrigger("PlayerDead");
//        }
//    }


    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 100)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}