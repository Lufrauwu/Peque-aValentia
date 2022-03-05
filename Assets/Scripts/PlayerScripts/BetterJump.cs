using UnityEngine;

public class BetterJump : MonoBehaviour
{
    [SerializeField] private float _fallMultiplier = default;
    [SerializeField] private float _lowJumpMultiplier = default;
    private Rigidbody2D _rigidBody2D = default;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(_rigidBody2D.velocity.y < 0)
        {
            _rigidBody2D.velocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_rigidBody2D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            _rigidBody2D.velocity += Vector2.up * Physics2D.gravity.y * (_lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
