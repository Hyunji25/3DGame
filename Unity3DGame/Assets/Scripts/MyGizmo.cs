using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmo : MonoBehaviour
{
    public Color color = Color.red;

    private void OnDrawGizmos()
    {
        // ** Gizmos�� ���� �����Ѵ�.
        Gizmos.color = color;

        // ** Gizmos �׸���
        Gizmos.DrawWireCube(this.transform.position, new Vector3(10, 10, 10));
    }
}
