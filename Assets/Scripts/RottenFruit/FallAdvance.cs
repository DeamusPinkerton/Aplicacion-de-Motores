using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAdvance : IAdvance
{
    Transform _transform;
    float _speed;

    public FallAdvance(Transform transform, float speed = 5)
    {
        _transform = transform;
        _speed = speed;
    }


    public void Advance()
    {
    }
}
