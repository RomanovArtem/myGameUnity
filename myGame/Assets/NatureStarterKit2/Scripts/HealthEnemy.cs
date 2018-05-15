using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{

    /// <summary>
    /// здоровье врага
    /// </summary>
    public int HP = 500;

    /// <summary>
    /// флаг, что повысили хп
    /// </summary>
    public bool upHP = false;

    public void AddDamage(int damage)
    {
        if (ScreensaverLevel.CurrentLevel == 3 && !upHP)
        {
            HP = 3000;
            upHP = true;
        }

        HP -= damage;
        if (HP == 0)
        {
            GetComponent<NavMesh>().DeathEnemy();
            ScreensaverLevel.CountDeadEnemies++;
            //if (ScreensaverLevel.CountDeadEnemies == ScreensaverLevel.CountDeadEnemies) Destroy(gameObject);
            InvokeRepeating("DestroyObject", 3f, 3f);
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

}
