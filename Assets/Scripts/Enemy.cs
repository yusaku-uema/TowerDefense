using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // HP
    public int hp;
    // �ړ��X�s�[�h
    public float speed;
    // �|�������ɓ���o���邨��
    public int gold;

    //�i�s���[�g
    public Route route;


    private int pointIndex;

    // ��x�������s�����
    void Start()
    {
        //  �i�s���[�g�i�[
        transform.position = route.points[0].transform.position;
    }

    // ���t���[�����s����
    void Update()
    {
        var v = route.points[pointIndex + 1].transform.position - route.points[pointIndex].transform.position;
        transform.position += v.normalized * speed * Time.deltaTime;

        var pv = transform.position - route.points[pointIndex].transform.position;
        if (pv.magnitude >= v.magnitude)
        {
            pointIndex++;
            if (pointIndex >= route.points.Length - 1)//�Ō�܂œ��B����
            {
                Destroy(gameObject);
                //TODO �v���C���[�Ƀ_���[�W
            }
        }
    }
}
