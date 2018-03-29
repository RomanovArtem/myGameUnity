using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
        #region Коррдинаты
        var aX = agent.nextPosition.x;
        var aY = agent.nextPosition.y;
        var aZ = agent.nextPosition.z;

        var tX = target.position.x;
        var tY = target.position.y;
        var tZ = target.position.z;
        #endregion

        var distance = CalculationDistance(aX, aY, aZ, tX, tY, tZ);
        /// бег
        if (distance <= 20 && distance > 8)
        {
            animator.SetFloat("Speed", 4);
            animator.SetFloat("Directional", 1);
            agent.speed = 9;
        }
        /// бастрая ходьба
        else if (distance <= 30 && distance > 20)
        {
            animator.SetFloat("Speed", 3);
            animator.SetFloat("Directional", 1);
            agent.speed = 6;
        }
        /// обычная ходьба
        else if (distance > 30)
        {
            animator.SetFloat("Speed", 2.1f);
            animator.SetFloat("Directional", 1);
            agent.speed = 4;
        }
        // атака
        else if (distance <= 8)
        {
            agent.speed = 2;
            animator.SetFloat("Speed", 5);
            animator.SetFloat("Directional", 1);
        }


        System.Diagnostics.Debug.WriteLine(distance);
    }

    /// <summary>
    /// расчет расстояния
    /// </summary>
    /// <param name="aX"></param>
    /// <param name="aY"></param>
    /// <param name="aZ"></param>
    /// <param name="tX"></param>
    /// <param name="tY"></param>
    /// <param name="tZ"></param>
    /// <returns></returns>
    public float CalculationDistance(float aX, float aY, float aZ, float tX, float tY, float tZ)
    {
        var x = aX - tX;
        var y = aY - tY;
        var z = aZ - tZ;
        var R = Math.Sqrt((x * x) + (y * y) + (z * z));
        return (float)R;
    }
}
