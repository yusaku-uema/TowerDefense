using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour
{
    //�X�e�[�W�I���֑J��
    public void StartButton()
    {
        SceneManager.LoadScene("StageSelect");
    }
    //�Q�[���I��:�{�^������Ăяo��
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }
}
