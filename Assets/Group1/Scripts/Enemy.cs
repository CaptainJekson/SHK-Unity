using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _speed;

    private Vector3 _target;

    private void Awake()
    {
        _target = transform.position;
    }

    private void Update()
    {
        RandomMove();
    }

    private void RandomMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        GenerateTargetPoint();
    }

    private void GenerateTargetPoint()
    {
        if (transform.position == _target)
            _target = Random.insideUnitCircle * _radius;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
