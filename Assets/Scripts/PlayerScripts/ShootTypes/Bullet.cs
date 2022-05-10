using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = default;
    [SerializeField] private int _damageAmount = default;
    [SerializeField] private Rigidbody2D _rigidBody2D = default;
    [SerializeField] private float _lifeTime = default;

    void Start()
    {
        _rigidBody2D.velocity = transform.right * _bulletSpeed;
    }

    private void Update()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        BasicEnemy _basicEnemy = hitInfo.GetComponent<BasicEnemy>();
        if (_basicEnemy != null)
        {
            _basicEnemy.TakeDamage(_damageAmount);
        }
        ChaseAndReturnEnemy _chaseEnemy = hitInfo.GetComponent<ChaseAndReturnEnemy>();
        if (_chaseEnemy != null)
        {
            _chaseEnemy.TakeDamage(_damageAmount);
        }
        Destroy(gameObject);
    }
}

