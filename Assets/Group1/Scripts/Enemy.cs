using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _speed;

    private Vector3 _target;

    private void Awake()
    {
        _target = Random.insideUnitCircle * _radius;
    }

    private void Update()
    {
        MoveToRandomPoint();
    }

    private void MoveToRandomPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            _target = Random.insideUnitCircle * _radius;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
