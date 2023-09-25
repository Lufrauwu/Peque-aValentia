using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miniboss : MonoBehaviour
{
   [Header("Idel")] 
   [SerializeField] private float _idleMoveSpeed = default;
   [SerializeField] private Vector2 _idleMoveDirection = default;

   [Header("AttackUpNDown")]
   [SerializeField] private Vector2 _attackMoveDirection = default;

   [Header("AttackPlayer")] 
   [SerializeField] private float _attackPlayerSpeed = default;
   [SerializeField] private Transform _player = default;
   private Rigidbody2D _enemyRB = default;
   private Vector2 playerPosition;

   [Header("AcidAttack")] 
   [SerializeField] private GameObject _acidBullet = default;
   [SerializeField] private float _acidForce = default;
   [SerializeField] private Transform _firePosition = default;

   [Header("Other")] 
   [SerializeField] private Transform groundCheckUp = default;
   [SerializeField] private Transform groundCheckDown = default;
   [SerializeField] private Transform groundCheckWall = default;
   [SerializeField] private float groundCheckRadius = default;
   [SerializeField] private LayerMask groundLayer = default;
  [SerializeField] private bool isTouchingUp;
  [SerializeField] private bool isTouchingDown;
  [SerializeField] private bool isTouchingWall;
  [SerializeField] private bool facingLeft;
  [SerializeField] private bool goingUp = true;


   private void Start()
   {
      _idleMoveDirection.Normalize();
      _attackMoveDirection.Normalize();
      _enemyRB = GetComponent<Rigidbody2D>();
   }

   private void GetPlayerPosition()
   {
      playerPosition = _player.position - _firePosition.position;
      playerPosition.Normalize();
   }

   private void Update()
   {
      isTouchingUp = Physics2D.OverlapCircle(groundCheckUp.position, groundCheckRadius, groundLayer);
      isTouchingDown = Physics2D.OverlapCircle(groundCheckDown.position, groundCheckRadius, groundLayer);
      isTouchingWall = Physics2D.OverlapCircle(groundCheckWall.position, groundCheckRadius, groundLayer);
     
     // IdleState();
     FlipTowardsPlayer();
      if (Input.GetKeyDown(KeyCode.Space))
      {
         ShootAcid();  
      }


   }

   private void ShootAcid()
   {
      GetPlayerPosition();
      GameObject acidBullet = Instantiate(_acidBullet, _firePosition.position, Quaternion.identity);
      acidBullet.AddComponent<Rigidbody2D>().velocity = playerPosition * _acidForce;
   }
   

   private void Flip()
   {
      facingLeft = !facingLeft;
      _idleMoveDirection.x *= -1;
      _attackMoveDirection.x *= -1;
      transform.Rotate(0,180,0);
   }

   private void IdleState()
   {
      if (isTouchingUp && goingUp)
      {
         ChangeDirection();
      }
      else if(isTouchingDown && !goingUp)
      {
         ChangeDirection();
      }

      if (isTouchingWall)
      {
         if (facingLeft)
         {
            Flip();
         } else if (!facingLeft)
         {
            Flip();
         }   
      }
      
      _enemyRB.velocity = _idleMoveSpeed * _idleMoveDirection;
   }
   

   private void ChangeDirection()
   {
      goingUp = !goingUp;
      _idleMoveDirection.y *= -1;
      _attackMoveDirection.y -= -1;
      
   }
   private void OnDrawGizmosSelected()
   {
      Gizmos.color = Color.cyan;
      Gizmos.DrawWireSphere(groundCheckUp.position, groundCheckRadius);
      Gizmos.DrawWireSphere(groundCheckDown.position, groundCheckRadius);
      Gizmos.DrawWireSphere(groundCheckWall.position, groundCheckRadius);
   }

   private void AttackPlayer()
   {
      playerPosition = _player.position - transform.position;
      playerPosition.Normalize();
      _enemyRB.velocity = playerPosition * _attackPlayerSpeed;
   }

   private void FlipTowardsPlayer()
   {
      float playerDirection = _player.position.x - transform.position.x;

      if (playerDirection > 0 && facingLeft)
      {
         Flip();
      }
      else if (playerDirection < 0 && !facingLeft)
      {
         Flip();
      }
   }
}
