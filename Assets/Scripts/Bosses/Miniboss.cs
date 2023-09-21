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
   [SerializeField] private float _attackMoveSpeed = default;
   [SerializeField] private Vector2 _attackMoveDirection = default;

   [Header("AttackPlayer")] 
   [SerializeField] private float _attackPlayerSpeed = default;
   [SerializeField] private Transform _player = default;
   private Rigidbody2D _enemyRB = default;
   private Vector2 playerPosition;

   [Header("Other")] 
   [SerializeField] private Transform groundCheckUp = default;
   [SerializeField] private Transform groundCheckDown = default;
   [SerializeField] private Transform groundCheckWall = default;
   [SerializeField] private float groundCheckRadius = default;
   [SerializeField] private LayerMask groundLayer = default;
   private bool isTouchingUp;
   private bool isTouchingDown;
   private bool isTouchingWall;
   private bool facingLeft;
   private bool goingUp = true;


   private void Start()
   {
      _idleMoveDirection.Normalize();
      _attackMoveDirection.Normalize();
      _enemyRB = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
      isTouchingUp = Physics2D.OverlapCircle(groundCheckUp.position, groundCheckRadius, groundLayer);
      isTouchingDown = Physics2D.OverlapCircle(groundCheckDown.position, groundCheckRadius, groundLayer);
      isTouchingWall = Physics2D.OverlapCircle(groundCheckWall.position, groundCheckRadius, groundLayer);
      //IdleState();
      if (Input.GetKeyDown(KeyCode.Space))
      {
         AttackPlayer();
      }
      FlipTowardsPlayer();
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
