using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    //�ʉ߂��郋�[�g��ۑ�
    public Point[] points;

    //�i�s���[�g�������₷���悤�ɂ���B
    void OnDrawGizmosSelected()
    {
        for (var index = 0; index < points.Length - 1; index++)
        {
            var from = points[index].transform.position;
            var to = points[index + 1].transform.position;
            Gizmos.DrawLine(from, to);
        }
    }
}
