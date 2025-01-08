using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //waveŠÇ—
    public Wave[] waves;

    //‰½wave‚©
    public int wave;

    //Œo‰ßŠÔ
    public float time;

    void Start()
    {
        
    }

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