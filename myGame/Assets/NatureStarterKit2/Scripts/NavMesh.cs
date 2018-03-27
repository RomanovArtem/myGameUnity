using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{

    public Transform target; // куда будет идти враг
    NavMeshAgent agent;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

        ChangeSpeed();
    }

    /// <summary>
    /// изменение скорости аниматора и бега
    /// </summary>
    void ChangeSpeed()
    {
        var direction = target.position - agent.nextPosition;
        if (direction.magnitude > 20)
        {
            animator.SetFloat("Speed", 4);
            agent.speed = 8;
        }
        else {
            animator.SetFloat("Speed", 2.1f);
            agent.speed = 4;
        }
    }
}
