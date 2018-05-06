using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHelper : MonoBehaviour
{
    /// <summary>
    /// откуда стреляем
    /// </summary>
    public Transform _spawn;

    /// <summary>
    /// свет от выстрела
    /// </summary>
    public GameObject _point;

    /// <summary>
    /// кол-во патронов и магазине и всего
    /// </summary>
    public AmmoPlayer ammoPlayer;

    /// <summary>
    /// свет от выстрела
    /// </summary>
    public GameObject _shootLight;

    private float _shootLightTime = 0.0f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(_shootLightTime > 0)
        {
            _shootLightTime -= 0.1f;
            _shootLight.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && (ammoPlayer.NumberBulletsInStore + ammoPlayer.AmmoCount) > 0)
        {
            _shootLight.SetActive(true);
            _shootLightTime = 0.2f;
            Ray ray = new Ray(_spawn.position, _spawn.forward * 10f);
            RaycastHit hit;
            /// если попали
            if (Physics.Raycast(ray, out hit))
            {
                _point.GetComponent<Light>().enabled = true; //
                _point.GetComponent<Light>().enabled = false; //
                Rigidbody rigidbody = hit.transform.gameObject.GetComponent<Rigidbody>();
                if (rigidbody != null)
                {
                    var damage = 25;
                    hit.transform.GetComponent<HealthEnemy>().AddDamage(damage);

                }
            }

            ammoPlayer.NumberBulletsInStore--;
        }
    }
}