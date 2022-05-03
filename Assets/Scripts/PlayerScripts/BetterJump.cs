using UnityEngine;
using UnityEngine.InputSystem;

public class BetterJump : MonoBehaviour
{
    [SerializeField] private float _fallMultiplier = default;
    [SerializeField] private float _lowJumpMultiplier = default;
    private Rigidbody2D _rigidBody2D = default;
    private PlayerController _playerController = default;
    private InputAction _inputJump = default;
    private bool _isPressing = false;

    private void Awake()
    {
        _playerController = new PlayerController();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _inputJump = _playerController.Land.Jump;
        _inputJump.Enable();
        _inputJump.started += context => _isPressing = true;
        _inputJump.canceled += context => _isPressing = false;
    }

    private void OnDestroy()
    {
        _inputJump.Disable();
    }

    private void Update()
    {
        JumpBetter();
    }

    private void JumpBetter()
    {
        if (_rigidBody2D.velocity.y < 0)
        {
            _rigidBody2D.velocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;

        }
        else if (_rigidBody2D.velocity.y > 0 && !_isPressing)
        {
            _rigidBody2D.velocity += Vector2.up * Physics2D.gravity.y * (_lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}

