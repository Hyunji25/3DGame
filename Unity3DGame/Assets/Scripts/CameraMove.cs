using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float Speed = 1000;

    private GameObject PlayerMove;
    private Vector3 CurrentPosition;

    float mx; // 마우스 X각도
    float my; // 마우스 Y각도

    void Start()
    {
        CurrentPosition = Vector3.zero;
    }

    void Update()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

        // P = P0 + vt : 변경 위치 = 현재 위치 + 속도 * 시간
        mx += hor * Speed * Time.deltaTime;
        my += ver * Speed * Time.deltaTime;

        if (my >= 90)
            my = 90;
        else if (my <= -90)
            my = -90;
        transform.eulerAngles = new Vector3(-my, mx, 0);

        //if (PlayerMove.GetComponent<PlayerMove>().canHide == true)
        if (PlayerMove.GetComponent<PlayerMove>().Hiding == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CurrentPosition = gameObject.transform.position;
                Debug.Log(CurrentPosition + "In");
                transform.position = new Vector3(0, -5, 0); // 숨은 장소 바닥으로
                PlayerMove.GetComponent<PlayerMove>().Hiding = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(transform.position + "Out");
                transform.position = CurrentPosition; // 원 위치로
                PlayerMove.GetComponent<PlayerMove>().Hiding = false;
            }
        }
    }
}