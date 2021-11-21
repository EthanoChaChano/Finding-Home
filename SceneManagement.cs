using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void ClickStart()
    {
        SceneManager.LoadScene("Game");
    }

    public void FinishGame()
    {
        SceneManager.LoadScene("GameScene");

    }
    public void quitGame()
    {
        Application.Quit();
    }
}
