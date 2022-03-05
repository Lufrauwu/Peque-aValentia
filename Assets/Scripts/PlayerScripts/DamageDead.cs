using UnityEngine;

public class DamageDead : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.ReduceHealth();
        }
    }
}
