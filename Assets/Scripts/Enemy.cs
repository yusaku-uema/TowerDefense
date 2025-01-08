using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // HP
    public int hp;
    // 移動スピード
    public float speed;
    // 倒した時に入手出来るお金
    public int gold;

    //進行ルート
    public Route route;


    private int pointIndex;

    // 一度だけ実行される
    void Start()
    {
        //  進行ルート格納
        transform.position = route.points[0].transform.position;
    }

    // 毎フレーム実行する
    void Update()
    {
        var v = route.points[pointIndex + 1].transform.position - route.points[pointIndex].transform.position;
        transform.position += v.normalized * speed * Time.deltaTime;

        var pv = transform.position - route.points[pointIndex].transform.position;
        if (pv.magnitude >= v.magnitude)
        {
            pointIndex++;
            if (pointIndex >= route.points.Length - 1)//最後まで到達した
            {
                Destroy(gameObject);
                //TODO プレイヤーにダメージ
            }
        }
    }
}
