using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    //Scene�r���[�ł����\���������
    private void OnDrawGizmos()
    {
        //UnityEditor��ł����L���ɂ��Ă�
#if UNITY_EDITOR
        UnityEditor.Handles.Label(transform.position, name);
#endif
    }
}
