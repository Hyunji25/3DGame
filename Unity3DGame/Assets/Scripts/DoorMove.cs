using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    private Animator Anim;

    public bool can;

    void Start()
    {
        can = false;
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (can)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Anim.SetBool("Opening", true);
                Debug.Log(Anim.GetBool("Opening"));
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            can = true;
            Debug.Log("can true");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            can = false;
            Debug.Log("can false");
        }
    }
}