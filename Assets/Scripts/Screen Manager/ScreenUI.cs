using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenUI : MonoBehaviour, IScreen
{
    Button[] _buttons;

    void Awake()
    {
        _buttons = GetComponentsInChildren<Button>();

        foreach (var button in _buttons)
        {
            button.interactable = false;
        }
    }

    public void Activate()
    {
        foreach (var button in _buttons)
        {
            button.interactable = true;
        }
    }

    public void Deactivate()
    {
        foreach (var button in _buttons)
        {
            button.interactable = false;
        }
    }

    public void Free()
    {
        Destroy(gameObject);
    }
}
