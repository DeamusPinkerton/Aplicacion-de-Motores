using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinuousAdvance : IAdvance
{
    Transform _transform;
    float _speed;

    public SinuousAdvance(Transform transform, float speed = 5)
    {
        _transform = transform;
        _speed = speed;
    }

    public void Advance()
    {
        int _chance = Random.Range(0, 2);
        if (_chance == 1)
        {
            _transform.position = _transform.position + new Vector3((_speed * 20), 0, 0) * Time.deltaTime;
        }
        if (_chance == 0)
        {
            _transform.position = _transform.position + new Vector3((_speed * -20), 0, 0) * Time.deltaTime;
        }
    }
}
