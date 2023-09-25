using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
   [SerializeField] private float _radius = default;
   [SerializeField] private GameObject _explosionAcid = default;
   [SerializeField] private float _explosionForce = default;
   public void Explosion()
   {
      Instantiate(_explosionAcid, transform.position, Quaternion.identity);
      Collider2D[] explosionObjects = Physics2D.OverlapCircleAll(transform.position, _radius);

      foreach (Collider2D collisioner in explosionObjects)
      {
          Rigidbody2D rb2D = collisioner.GetComponent<Rigidbody2D>();
          if (rb2D !=null && !collisioner.gameObject.CompareTag("Player"))
          {
              Vector2 direction = collisioner.transform.position - transform.position;
              float distance = 1 + direction.magnitude;
              float finalForce = _explosionForce / distance;
              rb2D.AddForce(direction * finalForce);
          }
      }
      Destroy(gameObject);
   }

   private void OnCollisionEnter2D(Collision2D col)
   {
       
       Explosion();
   }

   private void OnDrawGizmos()
   {
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(transform.position, _radius);
   }
}

