using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public void QuitApplication()
    {
        Application.Quit();
    }
    public void TitleScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("TitleScene");
    }

    public void SpaceScene()
    {
        Time .timeScale = 1.0f;
        SceneManager.LoadScene("SpaceLevel");
    }

    public void JungleScene()
    {
        Time .timeScale = 1.0f;
        SceneManager.LoadScene("JungleLevel");
    }

    public void OceanScene()
    {
        Time .timeScale = 1.0f;
        SceneManager.LoadScene("OceanLevel");
    }

}
