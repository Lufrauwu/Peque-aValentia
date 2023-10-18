using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDrop : MonoBehaviour
{
    
    public Animator _animator = default; 
    private void Start()
    {
       // Physics2D.IgnoreCollision();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _animator.SetTrigger("Explosion");
        }
    }
    
    
    
}
