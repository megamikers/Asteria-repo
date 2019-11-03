using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdAgent : MonoBehaviour
{
    [SerializeField]
    Transform target;

    private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = Random.Range(3.0f, 7.0f);
        agent.SetDestination(target.position);
    }
}
