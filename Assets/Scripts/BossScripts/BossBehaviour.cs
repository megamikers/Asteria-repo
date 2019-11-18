using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Controls the enemy AI

public class BossBehaviour : MonoBehaviour
{
    // Member Variables
    public float bossSpeed = 0.5f;              // Adjust the enemy's speed
    public Transform __player;                  // The position of the player
    public Transform bossTransform;            // The position of the enemy 
    public bool notDead = true;                 // Determine if the player is dead or not
   // Animator anim;                              // Reference to the animator component.
   // GameObject _player;                          // Reference to the player GameObject.
   // PlayerHealth playerHealth;                  // Reference to the player's health.
   // bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.

    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.

    //Prefab fab;
    Animator anim;                              // Reference to the animator component.
    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    BossHealth BossHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.


    void Awake()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        BossHealth = GetComponent<BossHealth>();
        anim = GetComponent<Animator>();
        //fab = GetComponent<Prefab>();
    }


    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject.CompareTag("Player"))
        {
            // ... the player is in range.
            SceneManager.LoadScene("Asteria Boss Scene");
        }
    }


    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }
    }


    void Update()
    {
        transform.LookAt(__player);
        transform.Translate(Vector3.forward * bossSpeed * Time.deltaTime);
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange && playerHealth.currentHealth != 0)
        {
            // ... attack.
            Attack();
        }

        // If the player has zero or less health...
        if (playerHealth.currentHealth <= 0)
        {
            // ... tell the animator the player is dead.
           // anim.SetTrigger("PlayerDead");
        }
    }


    void Attack()
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
            anim.Play("attack1");
           
        }
    }
    /*
    // Update is called once per frame
    void Update()
    {
        // Look at the player, Follow the player 
        // and Move towards the player at the 
        // below rate 
        transform.LookAt(player);
        transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
    }
    void Awake()
    {
        // Setting up the references.
        _player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = _player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
    }
    */

}
