using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviour
{
    //‚Ç‚ÌPlayer‚Ìî•ñ‚ğ•\¦‚·‚é‚©
    public Player player;

    //Player‚ÌHPî•ñ
    public Text hpText;
    
    //Player‚ÌŠ‹à
    public Text goldText;

    void Update()
    {
        hpText.text = $"HP:{player.hp}";
        goldText.text = $"GOLD:{player.gold}";
    }
}
