using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    [SerializeField] Transform _mainGame;

    [SerializeField] Transform _canvasFather;

    
    void Start()
    {
        ScreenManager.Instance.Push(new ScreenGO(_mainGame));
    }

    public void OptionsMenu()
    {
        var ScreenOptions = Instantiate(Resources.Load<ScreenOptions>("SettingsMenu"), _canvasFather);
        ScreenManager.Instance.Push(ScreenOptions);
    }
    public void MenuBack()
    {
        ScreenManager.Instance.Pop();
    }
}
