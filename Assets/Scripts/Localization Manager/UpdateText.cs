using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(1)]
public class UpdateText : MonoBehaviour
{
    LanguageManager _langManager;
    void Start()
    {
        LanguageManager.instance.Force();
    }
    void Awake()
    {
        //_langManager = FindObjectOfType<LanguageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
