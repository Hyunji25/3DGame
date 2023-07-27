using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    private Transform target = null;
    private float Speed;

    void Start()
    {
        Speed = 2.0f;
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            target = col.gameObject.transform;
            Debug.Log("Target found");
        }
    }

    private void OnTriggerExit(Collider col)
    {
        target = null;
        Debug.Log("Target lost");
    }
}
