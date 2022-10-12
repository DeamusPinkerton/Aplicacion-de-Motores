using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        if (PlayerPrefs.GetInt("HasDoneTutorial") > 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void FinishTutorial()
    {
        PlayerPrefs.SetInt("HasDoneTutorial", 1);
        SceneManager.LoadScene(1);
    }
}
