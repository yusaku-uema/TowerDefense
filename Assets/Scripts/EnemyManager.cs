using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //wave管理
    public Wave[] waves;

    //何waveか
    public int wave;

    //経過時間
    public float time;



    //まだこのwaveで出現してない敵＋画面上の敵の数
    public int EnemyCnt => waves[wave].patterns.Count + FindObjectsOfType<Enemy>().Length;


    // Update is called once per frame
    void Update()
    {
        wave = 0;
        time += Time.deltaTime;
        CreateEnemy();
        
    }

    public void CreateEnemy()
    {
        foreach (var pattern in waves[wave].patterns)
        {
            if (pattern.time <= time)
            {
                var enemy = Instantiate(pattern.enemy, new Vector3(-1000, -1000), Quaternion.identity);
                enemy.route = pattern.route;
            }
        }

        waves[wave].patterns.RemoveAll(pattern => pattern.time <= time);
    }

}

[Serializable]
public class Wave
{
    public List<EnemyPattern> patterns;
}

[Serializable]
public class EnemyPattern
{
    public float time;
    public Enemy enemy;
    public Route route;
}