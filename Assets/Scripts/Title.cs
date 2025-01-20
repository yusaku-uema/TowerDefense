using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour
{
    //ステージ選択へ遷移
    public void StartButton()
    {
        SceneManager.LoadScene("StageSelect");
    }
    //ゲーム終了:ボタンから呼び出す
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
}
