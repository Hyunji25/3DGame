using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    private GameObject player;
    private bool check;
    private bool inout;

    void Start()
    {
        player = GameObject.Find("Player");
        check = false;
        inout = false;
    }

    private void OnTriggerEnter(Collider coll)
    {
        inout = true;
        if (inout && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("HIDE");
            GameObject.Find("Hide").transform.Find("CM").gameObject.SetActive(check);
            check = !check;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        inout = false;
        GameObject.Find("Hide").transform.Find("CM").gameObject.SetActive(false);
    }

    void Update()
    {
        
        //hide.SetActive(false);
        //hide.transform.Find("Camera").gameObject.SetActive(false);
    }
}


/*
 transform.position
 
 
 */