using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHelper : MonoBehaviour
{
    /// <summary>
    /// аниматор
    /// </summary>
    public Animator _anim;

    public bool _shooting = false;

    public LineRenderer _shootLine;

    /// <summary>
    /// координаты, откуда будет вылет пули
    /// </summary>
    public Transform _shootTransform;


    // Use this for initialization
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")/* && !Input.GetKey(KeyCode.LeftShift)*/)
        {
            //_anim.SetTrigger("Fire1");
            _shootLine.enabled = true;
            _shooting = true;
        }
    }

    void FixedUpdate()
    {
        if (_shooting)
        {
            _shooting = false;
            RaycastHit hit;
            _shootLine.SetPosition(0, _shootTransform.position);

            // есть попадение 
            if (Physics.Raycast(_shootTransform.position, -_shootTransform.right, out hit, 50f))
            {
                Debug.Log(hit.point);
                _shootLine.SetPosition(1, hit.point);
            }
            else
            {
                _shootLine.SetPosition(1, _shootTransform.position + transform.forward * 50f);

            }

            // скрывание линии
           // StartCoroutine(HideLine());
        }
    }

    private IEnumerator HideLine()
    {
        yield return new WaitForSeconds(0.1f); /// 100 млс
        _shootLine.enabled = false;
    }
}
