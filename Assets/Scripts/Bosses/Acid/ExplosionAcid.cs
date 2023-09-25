
using UnityEngine;

public class ExplosionAcid : MonoBehaviour
{
    [SerializeField] private float _radius = default;
    [SerializeField] private float _explosionForce = default;
    void Start()
    {
        Explosion();
    }
    
    public void Explosion()
    {
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
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
