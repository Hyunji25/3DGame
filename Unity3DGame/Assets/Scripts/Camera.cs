using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float Speed = 1000;

    float mx; // 마우스 X각도
    float my; // 마우스 Y각도

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
    }
}
