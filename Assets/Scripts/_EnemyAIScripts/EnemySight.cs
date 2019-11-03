using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Enemy Sight script
public class EnemySight : MonoBehaviour
{
    [SerializeField] private float fieldOfViewAngle = 110f;

    // Determines if the player is in sight
    [SerializeField] bool playerInSight;

    // Stores the last global position 
    // the non-NPC was spotted.
    [SerializeField] Vector3 personalLastSighting;

    // NavmeshAgent Component
    private NavMeshAgent nav;
    // SphereColl
    private SphereCollider col;

    // Reference to the Animator controller.
    private Animator anim;

    //private LastPlayerSighting lastPlayerSighting;

    // Reference to the the player game object.
    private GameObject player;

    // Reference to the player's animator.
    private Animator playerAnim;

    // Reference to the Player's Health Script.
    private PlayerHealth playerHealth;

    private HashIDs hash;

    // Previous personal last sighting
    // from the last frame to determine
    // if the position has changed.
    private Vector3 previousSighting;

    // When the game starts...
    void Awake()
    {
        // Store variable references in variables
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        anim = GetComponent<Animator>();

        // lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();

        // player = GameObject.FindGameObjectWithTag(Tags.player);
        playerAnim = player.GetComponent<Animator>();        
        playerHealth = player.GetComponent<PlayerHealth>();
        //hash = GameObject.FindGameObjectWithTag(Tags, gameController).GetComponent<HashIDs>();

        //personalLastSighting = lastPlayerSighting.resetPosition;
        //previousSighting = lastPlayerSighting.resetPosition;

    }

    void Update()
    {
        /* if (lastPlayerSighting.position != previousSighting)
             personalLastSighting = lastPlayerSighting.position;*/

        //previousSighting = lastPlayerSighting.position;

      /* if (playerHealth.currentHealth > 0f)
        {
            anim.SetBool(hash.playerInSightBool, playerInSight);
        }
        else
            anim.SetBool(hash.playerInSightBool, false);*/
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInSight = false;

            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if (angle < fieldOfViewAngle * 0.5f)
            {
                RaycastHit hit;

                if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
                {
                    if(hit.collider.gameObject == player)
                    {
                        playerInSight = true;
                        //lastPlayerSighting.position = player.transform.position;
                    }
                }
            }

        }
    }




}
