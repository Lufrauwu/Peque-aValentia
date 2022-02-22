using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject _key;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_key.activeSelf)
        {
            _key.SetActive(false);
        }
    }
}
