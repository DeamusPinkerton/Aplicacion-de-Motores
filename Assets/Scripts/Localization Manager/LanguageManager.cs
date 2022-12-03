using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public enum Language
{
    eng,
    spa
}

public class LanguageManager : MonoBehaviour
{
    [SerializeField]
    string _externalURL = "https://docs.google.com/spreadsheets/d/e/2PACX-1vRuw7cBbviS01tUPio5oR3NycgSkv5nPQoYyCoicqBy8Mc51Huy02XWpYrdgLKpXPrtc-K-NmtL93Rj/pub?output=csv";
    [SerializeField]
    Language _selectedLanguage;
    Dictionary<Language, Dictionary<string, string>> _languageManager;
    public event Action onUpdate = delegate { };

    void Start()
    {
        StartCoroutine(DownloadCSV(_externalURL));
    }

    
    void Update()
    {
        if (PlayerPrefs.GetInt("Language") == 1)
        {
            _selectedLanguage = Language.spa;
        }
        else
        {
            _selectedLanguage = Language.eng;
        }
        onUpdate();
    }

    public void SwapLanguage()
    {
        if (_selectedLanguage == Language.eng)
        {
            PlayerPrefs.SetInt("Language", 1);
            _selectedLanguage = Language.spa;
        }
        else
        {
            PlayerPrefs.SetInt("Language", 0);
            _selectedLanguage = Language.eng;
        }
        onUpdate();
    }

    public string GetTranslate(string id)
    {
        if (!_languageManager[_selectedLanguage].ContainsKey(id))
        {
            return "Error 404, Not Found";
        }
        else
        {
            return _languageManager[_selectedLanguage][id];
        }
    }

    IEnumerator DownloadCSV(string url)
    {
        var www = new UnityWebRequest(url);
        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        _languageManager = LangCodex.LoadCodexFromString("www", www.downloadHandler.text);

        //llamar funcion

        onUpdate();
    }
}

