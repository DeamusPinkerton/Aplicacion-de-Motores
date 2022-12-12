using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[DefaultExecutionOrder(1)]
public class TextTranslator : MonoBehaviour
{
    [SerializeField]
    string _ID;
    //[SerializeField]
    //LanguageManager _langManager;
    [SerializeField]
    TextMeshProUGUI _myView;
    LanguageManager _langManager;

    void Awake()
    {
        //_langManager = FindObjectOfType<LanguageManager>();
        //Debug.Log(_langManager);
        //_langManager.onUpdate += ChangeLange;
        LanguageManager.instance.onUpdate += ChangeLange;
    }

    void ChangeLange()
    {
        _myView.text = LanguageManager.instance.GetTranslate(_ID);
    }

    //private void OnDisable()
    //{
    //    LanguageManager.instance.onUpdate -= ChangeLange;
    //}
}
