using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    [SerializeField] private float _enemyVelocity = default;
    [SerializeField] private float _enemyDistance = default;
    [SerializeField] private Transform _groundCheck = default;
    [SerializeField] private bool _movingRigth = default;
    private Rigidbody2D _rigidBody2d = default;

    private void Start()
    {
        _rigidBody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D _checkFloor = Physics2D.Raycast(_groundCheck.position, Vector2.down, _enemyDistance);
        _rigidBody2d.velocity = new Vector2(_enemyVelocity, _rigidBody2d.velocity.y);

        if(_groundCheck == false)
        {
            Turn();
        }
    }

    private void Turn()
    {
        _movingRigth = !_movingRigth;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        _enemyVelocity *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_groundCheck.transform.position, _groundCheck.transform.position + Vector3.down * _enemyDistance);
    }
}
