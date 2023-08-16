using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float Speed;
    private Rigidbody PRigidbody;
    float gravity; // ม฿ทย

    CharacterController cc;

    private void Awake()
    {
        cc = gameObject.GetComponent<CharacterController>();
    }

    void Start()
    {
        Speed = 15.0f;
        gravity = 75.0f;
    }

    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(hor, 0, ver);
        dir.Normalize();

        dir = Camera.main.transform.TransformDirection(dir);

        dir.y -= gravity * Time.deltaTime;

        cc.Move(dir * Speed * Time.deltaTime);
    }
}