using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFactory : MonoBehaviour
{
    public static BombFactory Instance
    {
        get
        {
            return _instance;
        }
    }
    static BombFactory _instance;

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

    public void ReturnFruit(Fruit g)
    {
        pool.ReturnObject(g);
    }
}
