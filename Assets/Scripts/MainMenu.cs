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
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void StoreMenu()
    {
        SceneManager.LoadScene(3);
    }
    public void FinishTutorial()
    {
        PlayerPrefs.SetInt("HasDoneTutorial", 1);
        SceneManager.LoadScene(1);
    }

    public void Minigame()
    {
        SceneManager.LoadScene(4);
    }
    public void ResetButton()
    {
        PlayerPrefs.SetInt("HasDoneTutorial", 0);
        PlayerPrefs.SetInt("FrootLoops", 0);
        PlayerPrefs.SetInt("currentStamina", 10);
        PlayerPrefs.SetInt("MaxStamina", 10);
        PlayerPrefs.SetInt("CosmicKnife", 0);
    }

}
