using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Stamina : MonoBehaviour
{
    [SerializeField] int maxStamina = 10;
    [SerializeField] float timeToRecharge = 10f;
    int currentStamina;

    DateTime nextStaminaTime;
    DateTime lastStaminaTime;

    bool recharging;

    [SerializeField] TextMeshProUGUI staminaText = null;
    [SerializeField] TextMeshProUGUI timerText = null;

    public Button PurshadeBtns;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("currentStamina"))
        {
            PlayerPrefs.GetInt("MaxStamina", 10);
            PlayerPrefs.SetInt("currentStamina", PlayerPrefs.GetInt("MaxStamina"));
        }
        maxStamina = PlayerPrefs.GetInt("MaxStamina");
        Load();
        StartCoroutine(RechargeStamina());
        CheckPurchaseable();
    }


    public bool HasEnoughStamina(int stamina) => currentStamina - stamina >= 0;

    IEnumerator RechargeStamina()
    {
        UpdateTimer();
        recharging = true;
        maxStamina = PlayerPrefs.GetInt("MaxStamina");
        while (PlayerPrefs.GetInt("currentStamina") < maxStamina)
        {
            DateTime currentTime = DateTime.Now;
            DateTime nextTime = nextStaminaTime;

            bool staminaAdd = false;

            while (currentTime > nextTime)
            {
                if (PlayerPrefs.GetInt("currentStamina") >= maxStamina) break;

                PlayerPrefs.SetInt("currentStamina", PlayerPrefs.GetInt("currentStamina") + 1);
                staminaAdd = true;
                UpdateStamina();
                CheckPurchaseable();

                DateTime timeToAdd = nextTime;

                if (lastStaminaTime > nextTime)
                    timeToAdd = lastStaminaTime;

                nextTime = AddDuration(timeToAdd, timeToRecharge);
            }

            if (staminaAdd)
            {
                nextStaminaTime = nextTime;
                lastStaminaTime = DateTime.Now;
            }

            UpdateTimer();
            UpdateStamina();
            Save();

            yield return new WaitForEndOfFrame();
        }

        recharging = false;
    }

    DateTime AddDuration(DateTime date, float duration)
    {
        return date.AddSeconds(duration);
    }

    public void UseStamina(int staminaToUse)
    {
        if (PlayerPrefs.GetInt("currentStamina") - staminaToUse >= 0)
        {
            PlayerPrefs.SetInt("currentStamina", PlayerPrefs.GetInt("currentStamina") - staminaToUse);
            UpdateStamina();

            if (!recharging)
            {
                nextStaminaTime = AddDuration(DateTime.Now, timeToRecharge);
                StartCoroutine(RechargeStamina());
            }
        }
        else
        {
            Debug.Log("I'm out of Stamina!");
        }

    }

    public void CheckPurchaseable()
    {
        maxStamina = PlayerPrefs.GetInt("MaxStamina");
        if (PlayerPrefs.GetInt("currentStamina") >= 5)
        {
          PurshadeBtns.interactable = true;
        }
         else
        {
          PurshadeBtns.interactable = false;
        }
    }
    void UpdateTimer()
    {
        maxStamina = PlayerPrefs.GetInt("MaxStamina");
        if (PlayerPrefs.GetInt("currentStamina") >= maxStamina)
        {
            timerText.text = "Full Stamina!";

            return;
        }


        TimeSpan timer = nextStaminaTime - DateTime.Now;

        timerText.text = timer.Minutes.ToString("00") + ":" + timer.Seconds.ToString("00");
    }

    void UpdateStamina()
    {
        maxStamina = PlayerPrefs.GetInt("MaxStamina");
        currentStamina = PlayerPrefs.GetInt("currentStamina");
        staminaText.text = currentStamina.ToString() + " / " + maxStamina.ToString();
    }

    void Save()
    {
        PlayerPrefs.SetInt("currentStamina", currentStamina);
        PlayerPrefs.SetString("nextStaminaTime", nextStaminaTime.ToString());
        PlayerPrefs.SetString("lastStaminaTime", lastStaminaTime.ToString());
    }

    void Load()
    {
        currentStamina = PlayerPrefs.GetInt("currentStamina");
        nextStaminaTime = StringToDateTime(PlayerPrefs.GetString("nextStaminaTime"));
        lastStaminaTime = StringToDateTime(PlayerPrefs.GetString("lastStaminaTime"));
    }

    DateTime StringToDateTime(string date)
    {
        if (string.IsNullOrEmpty(date))
            return DateTime.Now;
        else
            return DateTime.Parse(date);
    }
}
