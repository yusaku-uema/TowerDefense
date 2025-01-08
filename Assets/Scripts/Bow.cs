using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{

    public Arrow arrowPrefab;

    //�|LV
    public int lv = 1;
    //LV�ɉ������U���͈�
    public float ShotRange => 1 + lv * 0.5f;
    //LV�ɉ������U�����x
    public float ShotInterval => 1.0f * Mathf.Pow(0.9f, lv);
    //LV�ɉ������p���[�A�b�v�R�X�g
    public int Cost => (int)(100 * Mathf.Pow(1.5f, lv));
    //LV�ɉ��������p�z
    public int Price => Cost / 2;


    void Start()
    {
        StartCoroutine(SearchAndShot());
    }

    private IEnumerator SearchAndShot()
    {
        while (true)
        {
            yield return new WaitForSeconds(ShotInterval);
            var collider = Physics2D.OverlapCircle(transform.position, ShotRange, LayerMask.GetMask("Enemy"));
            if (collider != null)
            {
                transform.rotation = Quaternion.FromToRotation(Vector3.right, collider.transform.position - transform.position);
                var arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
                arrow.targetEnemy = collider.GetComponent<Enemy>();
            }
        }
    }
}
