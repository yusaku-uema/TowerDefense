using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviour
{
    //�ǂ�Player�̏���\�����邩
    public Player player;

    //Player��HP���
    public Text hpText;
    
    //Player�̏�����
    public Text goldText;

    void Update()
    {
        hpText.text = $"HP:{player.hp}";
        goldText.text = $"GOLD:{player.gold}";
    }
}
