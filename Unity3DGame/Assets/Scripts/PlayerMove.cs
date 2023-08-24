using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private CameraMove cameraController;
    private Movement movement3D;

    public bool canHide; // 숨을 수 있다 없다
    public bool Hiding; // 숨어있다 아니다
    private Vector3 CurrentPosition;

    private bool isPaused;

    private void Awake()
    {
        movement3D = GetComponent<Movement>();
        canHide = false;
        Hiding = false;
        CurrentPosition = Vector3.zero;
        isPaused = false; // 정지상태인가
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        movement3D.MoveTo(new Vector3(x, 0, z));

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.transform.gameObject);

            if (hit.transform.gameObject.tag == "Lock")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Time.timeScale = 0;
                }
                if (Input.GetMouseButtonDown(1))
                {
                    Time.timeScale = 1;
                }
            }
        }
        
        /*
        if (canHide == true)
        {
            if (Hiding == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    CurrentPosition = gameObject.transform.position;
                    Debug.Log(CurrentPosition + "In");
                    transform.position = new Vector3(0, -5, 0); // 바닥으로
                    Hiding = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log(transform.position + "Out");
                    transform.position = CurrentPosition; // 원 위치로
                    Hiding = false;
                }
            }
        }
         */
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Hide")
        {
            canHide = true;
        }
        else
        {
            canHide = false;
        }
    }
}

/*
        if (Hiding == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CurrentPosition = gameObject.transform.position;
                Debug.Log(CurrentPosition);
                transform.position = new Vector3(0, -5, 0); // 바닥으로
                Hiding = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.position = CurrentPosition; // 원 위치로
                Hiding = false;
            }
        }
 */