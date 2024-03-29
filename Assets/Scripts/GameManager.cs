using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public Image FadeImage;
    public Image PuajImage;
    public GameObject timesUp;
    public GameObject multiplier;
    public TextMeshProUGUI FrootsText;
    public TextMeshProUGUI ScoreInMenuText;
    public TextMeshProUGUI FrootsInMenuText;

    public float Multiplier = 0;

    private Blade blade;
    private Spawner spawner;

    private int score;
    public static bool GameStop;
    private void Awake()
    {
        blade = FindObjectOfType<Blade>();
        spawner = FindObjectOfType<Spawner>();
        FrootsText.text = PlayerPrefs.GetInt("FrootLoops").ToString();
    }

    private void Start()
    {
        timesUp.SetActive(false);
        NewGame();
        GameStop = false;
    }

    private void NewGame()
    {
        blade.enabled = true;
        spawner.enabled = true;
        //score = 0;
        //ScoreText.text = score.ToString();

        Time.timeScale = 1f;
        ClearScene();
    }

    private void Update()
    {
        MultiplierTimer();
    }

    private void ClearScene()
    {
        Fruit[] fruits = FindObjectsOfType<Fruit>();

        foreach (Fruit fruit in fruits)
        {
            Destroy(fruit.gameObject);
        }
        
        Bomb[] bombs = FindObjectsOfType<Bomb>();

        foreach (Bomb Bomb in bombs)
        {
            Destroy(Bomb.gameObject);
        }
    }

    public void IncreaseScore(int amount)
    {
        if (Multiplier > 0)
        {
            if (amount > 0)
            {
                amount = (amount * 2);
            }
        }
        score += amount;
        ScoreText.text = score.ToString();
    }
    public void PointMultiplier(int amount)
    {
        Multiplier += amount;
    }

    public void Explode()
    {
        StartCoroutine(ExplodeSequence());
    }
    public void RottenFruit()
    {
        StartCoroutine(Puaj(true));
    }
    public void MultiplierTimer()
    {
        multiplier.SetActive(true);
        if (Multiplier > 0)
        {
            Multiplier -= Time.deltaTime;
        }
        else
        {
            multiplier.SetActive(false);
            Multiplier = 0;
        }
    }

    public void TimesUp()
    {
        blade.enabled = false;
        timesUp.SetActive(true);
        spawner.enabled = false;
        ScoreInMenuText.text = score.ToString();
        if (score > 0)
        {
            int currentLoops = (score / 20);
            PlayerPrefs.SetInt("LastLoops", currentLoops);
            int loops = (currentLoops + PlayerPrefs.GetInt("FrootLoops"));
            PlayerPrefs.SetInt("FrootLoops", loops);
            FrootsInMenuText.text = currentLoops.ToString();
        }
        else 
        {
            int currentLoops = 0;
            FrootsInMenuText.text = currentLoops.ToString();
        }
        ClearScene();
    }

    private IEnumerator ExplodeSequence()
    {
        float elapsed = 0f;
        float duration = 0.5f;

        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);

            FadeImage.color = Color.Lerp(Color.clear, Color.white, t);

            Time.timeScale = 1f - t;

            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(1f);

        TimesUp();

        elapsed = 0f;

        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);

            FadeImage.color = Color.Lerp(Color.white, Color.clear, t);

            Time.timeScale = 1f - t;

            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

    }
    private IEnumerator Puaj(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                PuajImage.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                PuajImage.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }

    }
}
