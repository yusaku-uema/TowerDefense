using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public String textAsset;

    public void StartButton()
    {
        SceneManager.LoadScene(textAsset);
    }


}
