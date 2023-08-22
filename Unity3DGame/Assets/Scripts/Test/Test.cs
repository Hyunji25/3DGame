using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public bool state;
    private Vector3 CurrentPosition;

    void Start()
    {
        state = false;
        CurrentPosition = Vector3.zero;
    }
    
    void Update()
    {
        if (state == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CurrentPosition = gameObject.transform.position;
                Debug.Log(CurrentPosition + "In");
                transform.position = new Vector3(0, 0, 0);
                state = true;
            }
        }
        else        
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(transform.position + "Out");
                transform.position = CurrentPosition; // 원 위치로
                state = false;
            }
        }
    }
}
