using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMoving : MonoBehaviour
{
    private Animator animator;

    private bool open;

    private void Start()
    {
        animator = GetComponent<Animator>();
        open = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("Open", open);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("Open", open);
            open = !open;
        }
    }
}
