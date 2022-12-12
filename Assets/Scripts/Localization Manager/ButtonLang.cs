using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLang : MonoBehaviour
{
    private Button _button;
    // Start is called before the first frame update
    void Start()
    {
        _button.onClick.AddListener(changeLanguage);
    }
    void Awake()
    {
        _button = GetComponent<Button>(); 
    }

    private void changeLanguage()
    {
        LanguageManager.instance.SwapLanguage();
    }

    void Update()
    {
    }
}
