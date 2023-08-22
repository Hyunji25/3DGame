using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private CameraMove cameraController;
    private Movement movement3D;

    public bool canHide; // ���� �� �ִ� ����
    public bool Hiding; // �����ִ� �ƴϴ�
    private Vector3 CurrentPosition;

    private void Awake()
    {
        movement3D = GetComponent<Movement>();
        canHide = false;
        Hiding = false;
        CurrentPosition = Vector3.zero;
    }

    private void Update()
    {
        if (canHide == true)
        {
            if (Hiding == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    CurrentPosition = gameObject.transform.position;
                    Debug.Log(CurrentPosition + "In");
                    transform.position = new Vector3(0, -5, 0); // �ٴ�����
                    Hiding = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log(transform.position + "Out");
                    transform.position = CurrentPosition; // �� ��ġ��
                    Hiding = false;
                }
            }
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        movement3D.MoveTo(new Vector3(x, 0, z));

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

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
                transform.position = new Vector3(0, -5, 0); // �ٴ�����
                Hiding = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.position = CurrentPosition; // �� ��ġ��
                Hiding = false;
            }
        }
 */