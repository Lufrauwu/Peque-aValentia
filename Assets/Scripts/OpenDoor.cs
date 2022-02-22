using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject key;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (key.activeSelf)
        {
            key.SetActive(false);
        }
    }
}
