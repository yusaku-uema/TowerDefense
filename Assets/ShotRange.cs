using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotRange : MonoBehaviour
{
    //‚Ç‚Ì‹|‚ÌUŒ‚”ÍˆÍ‚ğ•\¦‚·‚é‚Ì‚©
    public Player player;
    public SpriteRenderer rangeRenderer;

    // Update is called once per frame
    void Update()
    {
        if (player.selectBow == null)
        {
            rangeRenderer.enabled = false;
        }
        else
        {
            rangeRenderer.enabled = true;
            rangeRenderer.transform.localScale = new Vector3(2, 2) * player.selectBow.ShotRange;
            rangeRenderer.transform.position = player.selectBow.transform.position;
        }
    }
}
