using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    NavMeshAgent e_Agent;
    float startWaitTime = 4.0f;
    float timeToRotate = 2.0f;
    float walkSpeed = 6.0f;
    float runSpeed = 9.0f;

    float viewRadius = 15.0f;
    float viewAngle = 90.0f;
    LayerMask playerMask;
    LayerMask obstacleMask; // Àå¾Ö¹°
    float meshResolution = 1.0f; // ?
    int edgeIterations = 4; // ?
    float edgeDistance = 0.5f;

    Transform[] wayPoints;
    int m_wayPointIndex;

    Vector3 playerLastPosition = Vector3.zero;
    Vector3 m_playerPosition;

    float m_WaitTime;
    float m_TimeToRotate;
    bool m_PlayerInRange;
    bool m_PlayerNear;
    bool m_IsPatrol;
    bool m_CaughtPlayer;

    void Start()
    {
        m_playerPosition = Vector3.zero;
        m_IsPatrol = true;
        m_CaughtPlayer = false;
        m_PlayerInRange = false;
        m_WaitTime = startWaitTime;
        m_TimeToRotate = timeToRotate;

        m_wayPointIndex = 0; 
        e_Agent = GetComponent<NavMeshAgent>();

        e_Agent.isStopped = false;
        e_Agent.speed = walkSpeed;
        e_Agent.SetDestination(wayPoints[m_wayPointIndex].position);
    }

    void Update()
    {
        
    }
}

