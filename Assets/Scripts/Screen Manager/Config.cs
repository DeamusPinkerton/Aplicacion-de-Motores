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
    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var res = Instantiate(_overlayGame);

            ScreenManager.Instance.Push(new ScreenGO(res));
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            
            var screenOptions = Instantiate(Resources.Load<ScreenOptions>("Options Screen"), _canvasFather);
            ScreenManager.Instance.Push(screenOptions);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScreenManager.Instance.Pop();
        }
    }
    */
    public void OptionsMenu()
    {
        //ScreenManager.Instance.Push("Options Screen", _canvasFather);
        /*
        var screenOptions = Instantiate(Resources.Load<ScreenOptions>("OptionsMenu"), _canvasFather);
        ScreenManager.Instance.Push(screenOptions);
        */
        var screenOptions = Instantiate(Resources.Load<SettingsMenu>("Options Screen"), _canvasFather);
        ScreenManager.Instance.Push(screenOptions);
    }
    public void MenuBack()
    {
        ScreenManager.Instance.Pop();
    }
}
