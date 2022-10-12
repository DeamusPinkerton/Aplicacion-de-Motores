using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        if (PlayerPrefs.HasKey("HasDoneTutorial"))
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
        PlayerPrefs.SetString("HasDoneTuorial", "yes");
        SceneManager.LoadScene(1);
    }
}
