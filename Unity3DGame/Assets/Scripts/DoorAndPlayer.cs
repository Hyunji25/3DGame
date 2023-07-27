using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAndPlayer : MonoBehaviour
{
    public float interactDiastance = 5.0f; // 문 열고 닫을때 사용

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactDiastance))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    hit.collider.transform.parent.GetComponent<DoorMove>().ChangeDoorState();
                }
            }
        }
    }
}
