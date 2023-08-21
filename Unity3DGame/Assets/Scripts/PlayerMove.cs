using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private CameraMove cameraController;
    private Movement movement3D;

    private bool canHide; // ���� �� �ִ� ����
    private bool Hiding; // �����ִ� �ƴϴ�

    private void Awake()
    {
        movement3D = GetComponent<Movement>();
        canHide = false;
        Hiding = false;
    }

    private void Update()
    {
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