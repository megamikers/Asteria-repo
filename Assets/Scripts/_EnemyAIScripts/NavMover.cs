﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class NavMover : MonoBehaviour
{ 
    MushroomMon_Ani_Test mushroom;
    Collider other;
    List<Transform> points = new List<Transform>();   // List of waypoint Transforms 

    private int destPoint = 0;
    private NavMeshAgent agent;
     
    public Transform player;

    public float followDistance = 20.0f;
    public float attackDistance = 10.0f;

    [Range(0.0f, 1.0f)]
    public float attackProbability = 0.5f;

    public WaypointSystem path;
    public float remainingDistance = 0.3f;
     
    void Start()
    {
        points = path.waypoints;

        agent = GetComponent<NavMeshAgent>();
        mushroom = GetComponent<MushroomMon_Ani_Test>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }
 
   void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Count == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Count;
    }
     
    void Update()
    {
        // The distance between the player and the NPC
        float dist = Vector3.Distance(player.transform.position, this.transform.position);

        bool follow = (dist < followDistance);
          
        if(follow)
        {
            float random = Random.Range(0.0f, 1.0f);
            if (random > (1.0f - attackProbability) && dist < attackDistance)
            {
                Debug.Log("Player Spotted");
                mushroom.AttackAni();
            }
            else
            {
                mushroom.RunAni();
            } 

            agent.SetDestination(player.transform.position);
        }

        // Choose the next destination point when the agent gets
        // close to the current one.
        if (agent.remainingDistance < remainingDistance)
            GotoNextPoint();
    }

  
}

