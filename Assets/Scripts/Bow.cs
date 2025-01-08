using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{

    public Arrow arrowPrefab;

    //‹|LV
    public int lv = 1;
    //LV‚É‰ž‚¶‚½UŒ‚”ÍˆÍ
    public float ShotRange => 1 + lv * 0.5f;
    //LV‚É‰ž‚¶‚½UŒ‚‘¬“x
    public float ShotInterval => 1.0f * Mathf.Pow(0.9f, lv);
    //LV‚É‰ž‚¶‚½ƒpƒ[ƒAƒbƒvƒRƒXƒg
    public int Cost => (int)(100 * Mathf.Pow(1.5f, lv));
    //LV‚É‰ž‚¶‚½”„‹pŠz
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
