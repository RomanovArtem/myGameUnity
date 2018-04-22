using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{

    /// <summary>
    /// здоровье врага
    /// </summary>
    public int HP = 100;

    public void AddDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            GetComponent<NavMesh>().DeathEnemy();
            ScreensaverLevel.CountDeadEnemies++;
            if (ScreensaverLevel.CountDeadEnemies == ScreensaverLevel.CountDeadEnemies) Destroy(gameObject);
            InvokeRepeating("DestroyObject", 5f, 3f);
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

}
