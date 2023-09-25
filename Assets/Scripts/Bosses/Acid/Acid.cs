using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
  
   [SerializeField] private GameObject _explosionAcid = default;
  
   

   private void OnCollisionEnter2D(Collision2D col)
   {
       Instantiate(_explosionAcid, transform.position, Quaternion.identity);
       Destroy(gameObject);
   }
   
   

   
}

