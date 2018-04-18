using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearanceEnemies : MonoBehaviour
{
    public Rigidbody ZombiePrefab;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Rigidbody ZombieClone = Instantiate(ZombiePrefab, new Vector3(Random.Range(-90f, 100f), 1, Random.Range(-100f, 90f)), Quaternion.Euler(0, 90, 0)) as Rigidbody;
            ZombieClone.velocity = new Vector3(0, 0, 1);
        }

    }
}
