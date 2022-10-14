using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAdvance : IAdvance
{
        Transform _transform;
        float _speed;

        public LeftAdvance(Transform transform, float speed = 5)
        {
            _transform = transform;
            _speed = speed;
        }

        public void Advance()
        {
            _transform.position = _transform.position + new Vector3((_speed * -5), 0, 0) * Time.deltaTime;
        }
}
