using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float Speed;
    private Rigidbody PRigidbody;
    float Velocity; // ม฿ทย

    CharacterController cc;

    private void Awake()
    {
        cc = gameObject.GetComponent<CharacterController>();
    }

    void Start()
    {
        Speed = 5.0f;
    }

    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(hor, 0, ver);
        dir.Normalize();

        dir = Camera.main.transform.TransformDirection(dir);

        Velocity += -9.8f * Time.deltaTime;
        dir.y = Velocity;

        cc.Move(dir * Speed * Time.deltaTime);
    }
}