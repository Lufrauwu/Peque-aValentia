using UnityEngine;

public class FallDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelManager.instance.Restart();
    }
}
