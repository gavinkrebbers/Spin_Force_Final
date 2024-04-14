using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonScript : MonoBehaviour
{
    public static int curScene;

    public GameObject levelUI;
    public GameObject settingsUI;
    public GameObject menuButtons;
    public void Reset()
    {
        int scene = PlayerHealth.currentScene.buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
    public void Levels()
    {
        menuButtons.SetActive(false);
        levelUI.SetActive(true);
    }
    public void Settings()
    {
        menuButtons.SetActive(false);
        settingsUI.SetActive(true);
    }
    public void BackToMenu()
    {
        menuButtons.SetActive(true);
        settingsUI.SetActive(false);
        levelUI.SetActive(false);
    }
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(curScene + 1);
    }
}
