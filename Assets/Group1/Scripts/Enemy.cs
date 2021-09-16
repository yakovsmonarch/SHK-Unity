using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 _target;
    private float _radius = 4f;
    private float _speed = 2f;

    private void Start()
    {
        _target = Random.insideUnitCircle * _radius;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position == _target)
            _target = Random.insideUnitCircle * _radius;
    }
}
