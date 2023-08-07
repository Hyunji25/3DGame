using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    private float gravity = -9.8f; // ��°��
    private Vector3 moveDirector;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (characterController.isGrounded == false)
        {
            moveDirector.y += gravity * Time.deltaTime;
        }
        characterController.Move(moveDirector * moveSpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        //moveDirector = direction;
        moveDirector = new Vector3(direction.x, moveDirector.y, direction.z);
    }
}
