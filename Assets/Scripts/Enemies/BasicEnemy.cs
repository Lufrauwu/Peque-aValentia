using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    private bool _mustPatrol = true;
    private bool _mustTurn = default;
    [SerializeField] private int _enemyHealth = 10;
    [SerializeField] private float _walkSpeed = 300;
    [SerializeField] private Rigidbody2D _rigidBody2d = default;
    [SerializeField] private Transform _groundCheck = default;
    [SerializeField] private LayerMask _groundLayer = default;
    [SerializeField] private Collider2D _bodyCollider = default;
    private void Update()
    {
        if (_mustPatrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if (_mustPatrol)
        {
            _mustTurn = !Physics2D.OverlapCircle(_groundCheck.position, 0.1f, _groundLayer);
        }
    }

    void Patrol()
    {
        if (_mustTurn || _bodyCollider.IsTouchingLayers(_groundLayer))
        {
            Flip();
        }
        _rigidBody2d.velocity = new Vector2(_walkSpeed * Time.fixedDeltaTime, _rigidBody2d.velocity.y);
    }

    void Flip()
    {
        _mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        _walkSpeed = _walkSpeed * -1;
        _mustPatrol = true;
    }

    public void TakeDamage(int _damageRecived)
    {
        _enemyHealth -= _damageRecived;
        if (_enemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}

