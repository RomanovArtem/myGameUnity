using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTriggerUI : MonoBehaviour
{
    /// <summary>
    /// жизнь уменьшается
    /// </summary>
    public int _valueDown;

    NavMesh navMesh = new NavMesh();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// вход в триггер
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            collider.GetComponent<HealthPlayer>()._health -= _valueDown;
        }
    }
}
