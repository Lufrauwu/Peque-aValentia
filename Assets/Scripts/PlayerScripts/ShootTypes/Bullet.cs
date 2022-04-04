using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = default;
    [SerializeField] private int _damageAmount = default;
    [SerializeField] private Rigidbody2D _rigidBody2D = default;

    void Start()
    {
        _rigidBody2D.velocity = transform.right * _bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        BasicEnemy _basicEnemy = hitInfo.GetComponent<BasicEnemy>();
        if (_basicEnemy != null)
        {
            _basicEnemy.TakeDamage(_damageAmount);   
        }
        Destroy(gameObject);
    }

}
