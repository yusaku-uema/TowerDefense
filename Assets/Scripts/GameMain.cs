using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    enum GAME_STATE
    {
        TITLE,
        GAME_PLAY,
        WAVE_CHANGE,
        WAVE_CLEAR,
        GAME_CLEAR,
        GAME_OVER
    }

    [SerializeField]
    private GAME_STATE state;
    [SerializeField]
    private Text stateText;
    [SerializeField]
    private EnemyManager enemyManager;
    [SerializeField]
    private Player player;

    private WaitUntil WaitAnyKey => new WaitUntil(() => Input.GetKeyDown("space"));

    void Start()
    {
        state = GAME_STATE.TITLE;
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        while (true)
        {
            switch (state)
            {
                case GAME_STATE.TITLE:
                    stateText.text = "スペースキーでスタート";
                    yield return WaitAnyKey;
                    state = GAME_STATE.WAVE_CHANGE;
                    break;
                case GAME_STATE.GAME_PLAY:
                    stateText.text = "";
                    enemyManager.time += Time.deltaTime;
                    enemyManager.CreateEnemy();

                    if (player.hp <= 0)
                    {
                        state = GAME_STATE.GAME_OVER;
                    }
                    else if (enemyManager.EnemyCnt == 0)
                    {
                        state = GAME_STATE.WAVE_CLEAR;
                    }
                    break;
                case GAME_STATE.WAVE_CHANGE:
                    stateText.text = $"WAVE {enemyManager.wave + 1}";
                    yield return new WaitUntil(() => Input.anyKeyDown);
                    state = GAME_STATE.GAME_PLAY;
                    break;
                case GAME_STATE.WAVE_CLEAR:
                    if (enemyManager.wave == enemyManager.waves.Length - 1)
                    {
                        stateText.text = "WAVE CLEAR";
                        yield return new WaitUntil(() => Input.anyKeyDown);
                        state = GAME_STATE.GAME_CLEAR;
                    }
                    else
                    {
                        stateText.text = $"WAVE CLEAR\nBONUS + {player.gold * 20 / 100}";
                        yield return new WaitUntil(() => Input.anyKeyDown);
                        enemyManager.wave++;
                        enemyManager.time = 0;
                        player.gold += player.gold * 20 / 100;
                        state = GAME_STATE.WAVE_CHANGE;
                    }
                    break;
                case GAME_STATE.GAME_CLEAR:
                    SceneManager.LoadScene("GameClear");
                    break;
                case GAME_STATE.GAME_OVER:
                    SceneManager.LoadScene("GameOver");
                    break;
            }

            yield return null;
        }
    }
}