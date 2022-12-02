using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    Stack<IScreen> _screenStack;

    static public ScreenManager Instance;

    void Awake()
    {
        Instance = this;

        _screenStack = new Stack<IScreen>();
    }

    public void Pop()
    {
        if (_screenStack.Count <= 1) return;

        _screenStack.Pop().Free();

        if (_screenStack.Count > 0)
        {
            _screenStack.Peek().Activate();
        }
    }

    public void Push(IScreen newScreen)
    {
        if (_screenStack.Count > 0)
        {
            _screenStack.Peek().Deactivate();
        }

        _screenStack.Push(newScreen);

        newScreen.Activate();
    }

    public void Push(string resourceName, Transform parent = null)
    {
        var newScreen = Instantiate(Resources.Load<GameObject>(resourceName), parent);

        Push(newScreen.GetComponent<IScreen>());
    }
}
