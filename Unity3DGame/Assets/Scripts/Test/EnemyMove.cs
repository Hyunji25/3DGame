using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    private Transform player;
    private Transform enemy;

    NavMeshAgent e_Agent;
    [SerializeField] Transform[] e_WayPoints = null;
    private int count;

    private Animator anim;

    private float damping = 10.0f; // 회전값을 저장하기 위한 변수
    public bool isChase = false; // 추격하고 있는가

    enum State
    {
        Idle,
        Walk,
        Run,
        Attack,
    }

    State state;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        enemy = GetComponent<Transform>();
        anim = GetComponent<Animator>();

        state = State.Idle;
        e_Agent = GetComponent<NavMeshAgent>();
        count = 0;
        e_Agent.speed = 5.0f;
        InvokeRepeating("MoveToNextWayPoint", 0f, 2f);
    }

    void Update()
    {
        if (isChase)
        {
            Chase();
        }

        Quaternion rot = Quaternion.LookRotation(player.position - enemy.position);
        enemy.rotation = Quaternion.Slerp(enemy.rotation, rot, Time.deltaTime * damping);

        if (state == State.Idle)
        {
            UpdateIdle();
        }

        else if (state == State.Walk)
        {
            UpdateWalk();
        }
    }

    private void Chase()
    {
        if (state == State.Run)
        {
            UpdateRun();
        }
        else if (state == State.Attack)
        {
            UpdateAttack();
        }
    }

    private void UpdateWalk()
    {
        e_Agent.speed = 1.0f;
    }

    private void UpdateAttack()
    {
        e_Agent.speed = 0;
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > 2)
        {
            state = State.Run;
            anim.SetTrigger("Run");
        }
    }

    private void UpdateRun()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= 2)
        {
            state = State.Attack;
            anim.SetTrigger("Attack");
        }
        e_Agent.speed = 2.0f;
        e_Agent.destination = player.transform.position;
    }

    private void UpdateIdle()
    {
        e_Agent.speed = 0;
        player = GameObject.Find("Player").transform;
        if (player != null) // 여기를 바꿔야함
        {
            state = State.Run;
            anim.SetTrigger("Run");
            if (isChase == false)
                isChase = true;
        }
        else
        {
            state = State.Walk;
            anim.SetTrigger("Walk");
        }
    }

    void MoveToNextWayPoint()
    {
        if (e_Agent.velocity == Vector3.zero)
        {
            e_Agent.SetDestination(e_WayPoints[count++].position);

            if (count >= e_WayPoints.Length)
            {
                count = 0;
            }
        }
    }
}

