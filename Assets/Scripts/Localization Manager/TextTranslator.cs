using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextTranslator : MonoBehaviour
{
    [SerializeField]
    string _ID;
    [SerializeField]
    LanguageManager _langManager;
    [SerializeField]
    TextMeshProUGUI _myView;

    void Awake()
    {
        _langManager.onUpdate += ChangeLange;
    }

    void ChangeLange()
    {
        _myView.text = _langManager.GetTranslate(_ID);
    }

    private void OnDisable()
    {
        _langManager.onUpdate -= ChangeLange;
    }
}
