using System;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private Vector3 _respawn = default;
    
    public void ChangeCheckPoint(Vector3 Location)
    {
        _respawn = Location;
    }

    public void Respawn(GameObject player)
    {
        player.transform.position = _respawn;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LevelManager.Instance.StartCoroutine("Transition");
            other.gameObject.GetComponent<HealthController>().ReduceHealth();
            Respawn(other.gameObject);
        }
        
    }
}
