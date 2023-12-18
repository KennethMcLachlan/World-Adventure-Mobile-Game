using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void QuitApplication()
    {
        Application.Quit();
    }
    public void TitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void SpaceScene()
    {
        SceneManager.LoadScene("SpaceLevel");
    }

    public void JungleScene()
    {
        SceneManager.LoadScene("JungleLevel");
    }

    public void OceanScene()
    {
        SceneManager.LoadScene("OceanLevel");
    }
}
