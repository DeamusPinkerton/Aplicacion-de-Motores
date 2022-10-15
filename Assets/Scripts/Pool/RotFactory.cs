using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotFactory : MonoBehaviour
{
    public static RotFactory Instance
    {
        get
        {
            return _instance;
        }
    }
    static RotFactory _instance;

    [SerializeField] Fruit _prefab;
    [SerializeField] int _initialStock;
    public ObjectPool<Fruit> pool;


    void Awake()
    {
        _instance = this;
        pool = new ObjectPool<Fruit>(FruitCreator, Fruit.TurnOn, Fruit.TurnOff, _initialStock);
    }

    Fruit FruitCreator()
    {
        return Instantiate(_prefab);
    }

    public void ReturnFruit(Fruit h)
    {
        pool.ReturnObject(h);
    }
}
