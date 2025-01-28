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

    //ステージ選択へ遷移
    public void StartButton()
    {
        SceneManager.LoadScene("StageSelect");
        audioSource.Play();
    }
    //ゲーム終了:ボタンから呼び出す
    public void EndGame()
    {
        audioSource.Play();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
}
