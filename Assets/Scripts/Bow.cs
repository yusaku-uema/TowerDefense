using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{

    public Arrow arrowPrefab;

    void Start()
    {
        StartCoroutine(SearchAndShot());
    }

    private IEnumerator SearchAndShot()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            //TODO ‚±‚±‚Å“G‚ğ’T‚µ‚ÄA–î‚ğŒ‚‚Â
            var collider = Physics2D.OverlapCircle(transform.position, 2.0f, LayerMask.GetMask("Enemy"));
            if (collider != null)
            {
                transform.rotation = Quaternion.FromToRotation(Vector3.right, collider.transform.position - transform.position);
                var arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
                arrow.targetEnemy = collider.GetComponent<Enemy>();
            }
        }
    }
}
