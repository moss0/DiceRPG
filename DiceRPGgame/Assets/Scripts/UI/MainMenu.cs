using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainStart;
    public GameObject selectLevel;
    public GameObject credits;
    private void Start()
    {
        mainStart.SetActive(true);
        selectLevel.SetActive(false);
        credits.SetActive(false);
    }
    public void ToLevelSelectScreen()
    {
        mainStart.SetActive(false);
        selectLevel.SetActive(true);
    }
    public void ToCreditsScreen()
    {
        mainStart.SetActive(false);
        credits.SetActive(true);
    }
    public void GoBack()
    {
        mainStart.SetActive(true);
        selectLevel.SetActive(false);
        credits.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }
}
