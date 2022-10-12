using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] int min, sec;
    [SerializeField] TextMeshProUGUI time;

    private float remaining;
    private bool Ongoing;

    private void Awake()
    {
        remaining = (min * 60) + sec;
        Ongoing = true;
    }
    private void Update()
    {
        if (Ongoing)
        {
            remaining -= Time.deltaTime;
            if (remaining < 1)
            {
                Ongoing = false;
                FindObjectOfType<GameManager>().TimesUp();
            }
        }

        int TempMin = Mathf.FloorToInt(remaining / 60);
        int TempSec = Mathf.FloorToInt(remaining % 60);
        time.text = string.Format("{00:00}:{01:00}",TempMin,TempSec);

        
    }
}
