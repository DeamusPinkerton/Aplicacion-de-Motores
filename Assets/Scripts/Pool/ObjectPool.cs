using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool<T>
{
    Func<T> _factoryMethod;
    List<T> _currentStock;
    bool _isDynamic;
    Action<T> _turOnCallback;
    Action<T> _turOffCallback;

    public ObjectPool(Func<T> factoryMethod, Action<T> turnOn, Action<T> turnOff, int initialStock = 0, bool isDynamic = true)
    {
        _factoryMethod = factoryMethod;
        _turOnCallback = turnOn;
        _turOffCallback = turnOff;
        _isDynamic = isDynamic;
        _currentStock = new List<T>();

        for (int i = 0; i < initialStock; i++)
        {
            T obj = _factoryMethod();
            _turOffCallback(obj);
            _currentStock.Add(obj);
        }
    }

    public T GetObject()
    {
        T result = default(T);

        if (_currentStock.Count > 0)
        {
            result = _currentStock[0];
            _currentStock.RemoveAt(0);
        }
        else if (_isDynamic)
        {
            result = _factoryMethod();
        }
        _turOnCallback(result);
        return result;
    }

    public void ReturnObject(T obj)
    {
        _turOffCallback(obj);
        _currentStock.Add(obj);
    }


}
