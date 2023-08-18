using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float Speed;
    private float RunSpeed;
    private Rigidbody PRigidbody;
    float gravity; // ม฿ทย
    float ygravity;

    CharacterController cc;

    private void Awake()
    {
        cc = gameObject.GetComponent<CharacterController>();
    }

    void Start()
    {
        Speed = 4.0f;
        RunSpeed = 6.0f;
        gravity = -9.8f;
    }

    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(hor, 0, ver);
        dir.Normalize();

        dir = Camera.main.transform.TransformDirection(dir);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += dir * RunSpeed * Time.deltaTime;
            //Debug.Log("In");
        }
        else
        {
            transform.position += dir * Speed * Time.deltaTime;
            //Debug.Log("Out");
        }

        ygravity += gravity * Time.deltaTime;
        dir.y = ygravity;

        cc.Move(dir * Speed * Time.deltaTime);
    }
}