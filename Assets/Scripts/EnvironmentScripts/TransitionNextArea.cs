using UnityEngine;

public class TransitionNextArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        LevelManager.Instance.NextScene();
    }
}
