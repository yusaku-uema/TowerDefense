using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�|Prefab
    public Bow bowPrefab;

    //HP(���_�̗̑�)
    public int hp;

    //GOLD(������)
    public int gold;

    //�I�𒆂̋|
    public Bow selectBow;

    //�ݒu��
    public AudioClip establishment;
    //���x���A�b�v
    public AudioClip levelup;
    //���p��
    public AudioClip sale;
    //�I����
    public AudioClip selection;

    AudioSource audioSource;


    void Start()
    {
        //Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    //�w��̏ꏊ�ɋ|�̌��݂��o����
    public void CreateBow(Transform t)
    {
        if (gold < 100) return;
        audioSource.PlayOneShot(establishment);
        gold -= 100;
        selectBow = Instantiate(bowPrefab, t);
        selectBow.transform.localPosition = Vector3.zero;
    }

    //�I�𒆂̋|�̃��x���A�b�v���o����
    public void LevelUpBow()
    {
        if (selectBow == null) return;  //�����I������Ă��Ȃ�
        if (gold < selectBow.Cost) return; //������������Ȃ�
        audioSource.PlayOneShot(levelup);
        gold -= selectBow.Cost;
        selectBow.lv++;
    }

    //�I�𒆂̋|�̔��p���o����
    public void SellBow()
    {
        if (selectBow == null) return;
        gold += selectBow.Price;
        Destroy(selectBow.gameObject);
        audioSource.PlayOneShot(sale);
        selectBow = null;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //�N���b�N�����ꏊ�������u����̂��̊m�F����

            //�X�N���[�����W�����[���h���W�ɕϊ�����
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var col = Physics2D.OverlapPoint(mousePos, LayerMask.GetMask("Block"));
            //�u����ꏊ�ȊO���N���b�N�����ꍇ�́A����
            if (col == null) return;
            //���ɕ��킪�u����Ă�����A�u����Ă��镐��̑I��
            var childBow = col.GetComponentInChildren<Bow>();
            if (childBow == null)
            {
                CreateBow(col.transform);
            }
            else
            {
                audioSource.PlayOneShot(selection);
                selectBow = childBow;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
           // SellBow();
        }
    }
}
