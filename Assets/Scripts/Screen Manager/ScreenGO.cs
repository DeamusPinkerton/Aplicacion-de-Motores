using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenGO : IScreen
{
    Dictionary<Behaviour, bool> _before;

    Transform _root;

    public ScreenGO(Transform root)
    {
        _root = root;

        _before = new Dictionary<Behaviour, bool>();

        foreach (var b in root.GetComponentsInChildren<Behaviour>())
        {
            b.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    public void Activate()
    {
        foreach (var keyValue in _before)
        {
            keyValue.Key.enabled = keyValue.Value;
        }
    }

    public void Deactivate()
    {
        foreach (var b in _root.GetComponentsInChildren<Behaviour>())
        {
            _before[b] = b.enabled;

            b.enabled = false;
        }
    }

    public void Free()
    {
        GameObject.Destroy(_root.gameObject);
    }


}
