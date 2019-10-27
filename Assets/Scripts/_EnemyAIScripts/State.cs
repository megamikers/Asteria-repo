using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class defines the different  
// states of the AI.
public class State : MonoBehaviour
{
    // Enemy states
    enum EnemyStates
    {
        // State machine variables
        IDLE,
        RUN,
        ATTACK,
        DAMAGE,
        DEATH
    }
}
