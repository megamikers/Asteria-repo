using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    Animator m_animator;
        void Start()
    {
        m_animator = GetComponent<Animator>();
    }
    void Update()
    {
        bool isWalkingPressed = Input.GetKey("up");
        m_animator.SetBool("IsWalking", isWalkingPressed);
        



        bool hasAttackPressed = Input.GetKey("1");
        m_animator.SetBool("hasAttack", hasAttackPressed);

        bool hasAttack2Pressed = Input.GetKey("2");
        m_animator.SetBool("hasAttack2", hasAttack2Pressed);



    }
}
