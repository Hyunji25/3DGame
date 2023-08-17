using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private float PlayerSpeed = 5;
    private float dashspeed = 10;

    private float gravity = -9.8f;
    private float yVelocity;
    private Vector3 dir;

    CharacterController cc;

    private void Awake()
    {
        cc = gameObject.GetComponent<CharacterController>();
    }

    void Start()
    {

    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        dir = new Vector3(h, 0, v);
        dir.Normalize();

        dir = Camera.main.transform.TransformDirection(dir);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
        }
        else
        {
            transform.position += dir * PlayerSpeed * Time.deltaTime;
            Debug.Log("Out");
        }

        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * PlayerSpeed * Time.deltaTime);
    }

    private IEnumerator Dash()
    {
        transform.position += dir * PlayerSpeed * dashspeed * Time.deltaTime;
        Debug.Log("In");
        yield return null;
    }
}
