using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //�ǂ̓G�Ɍ������Ĕ�Ԃ̂��w�肷��
    public Enemy targetEnemy;

    //�ړ��X�s�[�h
    private float speed = 10;

    void Update()
    {
        if (targetEnemy == null)
        {
            Destroy(gameObject);
            return;
        }

        var v = targetEnemy.transform.position - transform.position;
        transform.position += v.normalized * speed * Time.deltaTime;

        if (v.magnitude < 0.7f)
        {
            targetEnemy.hp -= 1;
            //targetEnemy.OnTriggerEnter2D();
            
            if (targetEnemy.hp <= 0)
            {
                Destroy(targetEnemy.gameObject);
                FindObjectOfType<Player>().gold += targetEnemy.gold;
            }
            transform.SetParent(targetEnemy.transform);
            enabled = false;
        }
    }
}
