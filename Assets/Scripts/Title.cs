using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour
{

    //SE
    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //�X�e�[�W�I���֑J��
    public void StartButton()
    {
        SceneManager.LoadScene("StageSelect");
        audioSource.Play();
    }
    //�Q�[���I��:�{�^������Ăяo��
    public void EndGame()
    {
        audioSource.Play();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }
}
