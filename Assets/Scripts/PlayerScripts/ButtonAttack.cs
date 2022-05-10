using System;
using UnityEngine;
using  UnityEngine.InputSystem;

public class ButtonAttack : MonoBehaviour
{
    [SerializeField] private Animator _animator = default;
    [SerializeField] private Transform _attackPoint = default;
    [SerializeField] private float _attackRange = default;
    [SerializeField] private LayerMask _enemyLayers = default;
    [SerializeField] private int _meleeDamage = default;
    private PlayerController _playerController = default;
    private InputAction _inputAttack = default;
    
    void Start()
    {
        _playerController = new PlayerController();
        _playerController.Enable();
        _inputAttack = _playerController.Land.Fire;
        _inputAttack.Enable();
        _playerController.Land.Fire.performed += _ => Attack();
    }

    void Attack()
    {
        _animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayers);
        foreach (Collider2D enemy in hitEnemies)  
        {
            enemy.GetComponent<BasicEnemy>().TakeDamage(_meleeDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}
