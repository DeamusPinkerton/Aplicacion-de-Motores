using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject pausemenu;
    Image img;
    public Sprite Playsprite;
    public Sprite Pauseprite;
    public GameObject _trailObj;

    private void Start()
    {
        img = GetComponent<Image>();
        //_trailObj = GetComponent<>(Blade);
    }
    public void OnpauseGame()
    {
        if (GameManager.GameStop == false)
        {
            Time.timeScale = 0f;
            img.sprite = Playsprite;
            GameManager.GameStop = true;
            pausemenu.SetActive(true);
            _trailObj.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            img.sprite = Pauseprite;
            GameManager.GameStop = false;
            pausemenu.SetActive(false);
            _trailObj.SetActive(true);
        }
    }
}
