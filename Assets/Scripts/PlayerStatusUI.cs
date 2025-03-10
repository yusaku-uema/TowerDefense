using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviour
{
    //どのPlayerの情報を表示するか
    public Player player;

    //PlayerのHP情報
    public Text hpText;
    
    //Playerの所持金
    public Text goldText;

    void Update()
    {
        hpText.text = $"HP:{player.hp}";
        goldText.text = $"GOLD:{player.gold}";
    }
}
