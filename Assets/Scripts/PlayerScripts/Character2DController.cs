
using UnityEngine;

public class Character2DController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = default;
    private float _horizontalMove = default;
    private void Start()
    {
        
    }
    private void Update()
    {
         _horizontalMove = Input.GetAxis("Horizontal");
        
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(_horizontalMove * Time.fixedDeltaTime, 0, 0) * _movementSpeed;
    }
}
