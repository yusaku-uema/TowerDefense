using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    //Sceneビューでだけ表示される矢印
    private void OnDrawGizmos()
    {
        //UnityEditor上でだけ有効にしてね
#if UNITY_EDITOR
        UnityEditor.Handles.Label(transform.position, name);
#endif
    }
}
