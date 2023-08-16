using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMoving : MonoBehaviour
{
    private bool isInsideTrigger = false;
    public Animator animator;
    private bool isOpen = false;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            isInsideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            isInsideTrigger = false;
        }
    }

    void Update()
    {
        if (isInsideTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOpen = !isOpen;
                animator.SetBool("Open", isOpen);
            }
        }
    }
}
