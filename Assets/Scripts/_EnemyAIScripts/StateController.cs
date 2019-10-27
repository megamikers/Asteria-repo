using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    State currentState;  // Reference to State Class
    MushroomMon_Ani_Test mushroomMon_Ani;

    // Initialize...
    private void Start()
    {
        // Initialize the State class reference
        currentState = GetComponent<State>(); 

        // Initialize the MushroomMOn_Ani_Test Class reference                   
        mushroomMon_Ani = GetComponent<MushroomMon_Ani_Test>();
    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            Debug.Log("Contact was made");
            // Activate the mushroom man's Attack animation
            mushroomMon_Ani.AttackAni();
           
        }
    }

    void OnTriggerExit(Collider other)
    {
        mushroomMon_Ani.RunAni();
    }

    // Attack function
    void Attack()
    {

    }

    // Damage function
    void Damage()
    {

    }

    // State of the AI
    void StateOfAI()
    {

    }
}
