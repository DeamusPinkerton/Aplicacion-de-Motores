using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public static Factory Instance
    {
        get
        {
            return _instance;
        }
    }
    static Factory _instance;

    [SerializeField] Fruit _prefab;
    [SerializeField] int _initialStock;
    public ObjectPool<Fruit> pool;


    void Awake()
    {
        _instance = this;
        /*
        if (Instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        */
        pool = new ObjectPool<Fruit>(FruitCreator, Fruit.TurnOn, Fruit.TurnOff, _initialStock);
    }

    Fruit FruitCreator()
    {
        return Instantiate(_prefab);
    }

    public void ReturnFruit(Fruit b)
    {
        pool.ReturnObject(b);
    }
}
