using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public Image FadeImage;
    public GameObject timesUp;
    public TextMeshProUGUI FrootsText;
    public TextMeshProUGUI ScoreInMenuText;
    public TextMeshProUGUI FrootsInMenuText;

    private Blade blade;
    private Spawner spawner;

    private int score;

    private void Awake()
    {
        blade = FindObjectOfType<Blade>();
        spawner = FindObjectOfType<Spawner>();
        FrootsText.text = PlayerPrefs.GetInt("FrootLoops", 0).ToString();
    }

    private void Start()
    {
        timesUp.SetActive(false);
        NewGame();
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
        score += amount;
        ScoreText.text = score.ToString();
    }

    public void Explode()
    {
        blade.enabled = false;
        spawner.enabled = false; 
        ScoreInMenuText.text = score.ToString();
        int currentLoops = (score / 20);
        int loops = (currentLoops + PlayerPrefs.GetInt("FrootLoops"));
        PlayerPrefs.SetInt("FrootLoops", loops);
        FrootsInMenuText.text = currentLoops.ToString();
        StartCoroutine(ExplodeSequence());
    }
    public void TimesUp()
    {
        blade.enabled = false;
        spawner.enabled = false;
        timesUp.SetActive(true);
        ScoreInMenuText.text = score.ToString();
        int currentLoops = (score / 20);
        int loops = (currentLoops + PlayerPrefs.GetInt("FrootLoops"));
        PlayerPrefs.SetInt("FrootLoops", loops);
        FrootsInMenuText.text = currentLoops.ToString();
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

        NewGame();

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
}
