using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoorMoving : MonoBehaviour
{
    void Update()
    {
        switch (GameData.GetInstance().LockDoor)
        {
            case 1:
                transform.Find("1F").gameObject.SetActive(false);
                break;
            case 2:
                transform.Find("2F").gameObject.SetActive(false);
                break;
            case 3:
                transform.Find("3F").gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}


/*
 PatrolWayPoint
 */