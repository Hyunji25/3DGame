using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public bool state;
    public GameObject Target;

    void Start()
    {
        state = false;
        Target = GameObject.Find("Cube");
    }
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)) // 마우스 왼쪽 클릭
        {
            GameObject.Find("Hide").transform.Find("CM").gameObject.SetActive(state);
            state = !state;
        }
    }
}
