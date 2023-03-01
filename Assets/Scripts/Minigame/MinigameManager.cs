using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public GameObject win, lose;
    public AudioSource _win;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Win();
        }
    }

    public void Win()
    {
        _win.Play();
        win.SetActive(true);
        int currentLoops = 25;
        PlayerPrefs.SetInt("LastLoops", currentLoops);
        int loops = (currentLoops + PlayerPrefs.GetInt("FrootLoops"));
        PlayerPrefs.SetInt("FrootLoops", loops);
    }
    public void Lose()
    {
        lose.SetActive(true);
    }
}
