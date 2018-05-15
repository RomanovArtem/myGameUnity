using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    /// <summary>
    /// типо времени, через которое заного можно будет атаковать
    /// </summary>
    public int _timer = 30;

    public Transform target; // куда будет идти враг

    NavMeshAgent agent = null;
    Animator animator;

    public GameObject Player;

    /// <summary>
    /// мертв ли юнит ?
    /// </summary>
    private bool _isDead = false;

    /// <summary>
    /// возвращает и задает свойство : мертв ли юнит ?
    /// </summary>
    public bool isDead
    {
        get { return _isDead; }
        set { _isDead = value; }
    }


    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (agent != null && !isDead)
        {
            agent.SetDestination(target.position);
            ChangeSpeed();
        }
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
        if (distance <= 30 && distance > 8)
        {
            animator.SetFloat("Speed", 4);
            animator.SetFloat("Directional", 1);
            agent.speed = 9;
        }
        /// бастрая ходьба
        else if (distance > 30)
        {
            animator.SetFloat("Speed", 3.5f);
            animator.SetFloat("Directional", 1);
            agent.speed = 6;
        }

        // атака
        else if (distance <= 8)
        {
            agent.speed = 2;
            animator.SetFloat("Speed", 5);
            animator.SetFloat("Directional", 1);
            if (distance <= 6 && _timer == 30)
            {
                Player.GetComponent<HealthPlayer>()._health -= 1;
            }
            _timer--;
            if (_timer == 0 || _timer < 0)
            {
                _timer = 30;
            }
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

    /// <summary>
    /// смерть врага
    /// </summary>
    public void DeathEnemy()
    {
        isDead = true;
        agent.speed = 0;
        animator.SetFloat("Speed", 5.9f);
    }
}
