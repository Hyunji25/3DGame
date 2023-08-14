using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    GameObject wp;
    public Transform[] waypoints;

    void Start()
    {
        wp = GameObject.Find("Environment");

        int wp_count = wp.transform.childCount;

        for (int i = 0; i < wp_count; ++i)
        {
            Debug.Log(wp.transform.GetChild(i).name);
            string name = wp.transform.GetChild(i).name;
            //waypoints[i] = GameObject.Find(wp.transform.GetChild(i).transform);
        } 

        
    }

    void Update()
    {
    }
}
