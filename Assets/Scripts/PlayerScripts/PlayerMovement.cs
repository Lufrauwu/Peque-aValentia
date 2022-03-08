using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpHeight = default;
    [SerializeField] private float _walkSpeed = default;
    [SerializeField] private float _checkRadius = default; 
    [SerializeField] private float _jumpTime = default;
    [SerializeField] Transform _feetTransform = default;
    [SerializeField] LayerMask _groundLayer = default;
    Rigidbody2D _rigidBody2D = default;
    private float _jumpCounter = default;
    private float _horizontalMove = default;
    private bool _isGrounded = default;
    private bool _isJumping = default;
    private bool _isDeath = false;
    private bool _facingRight = true;
    private PlayerController _playerController = default;

    private void Awake()
    {
        _playerController = new PlayerController();
    }

    private void OnEnable()
    {
        _playerController.Enable();
    }

    private void OnDisable()
    {
        _playerController.Disable();
    }

    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
       // _playerController.Land.Jump.performed += _ => Jump();
    }

    void Update()
    {
        if (_isDeath)
        {
            return;
        }
        _horizontalMove = _playerController.Land.Move.ReadValue<float>();
        Vector3 currentPosition = transform.position;
        currentPosition.x += _horizontalMove * _walkSpeed * Time.deltaTime;
        transform.position = currentPosition;
        if (_horizontalMove < 0 &&_facingRight)
        {
            Flip();
        }
        else if (_horizontalMove > 0 && !_facingRight)
        {
            Flip();
        }
        _isGrounded = Physics2D.OverlapCircle(_feetTransform.position, _checkRadius, _groundLayer);
       /* if (_isGrounded == true && Input.GetButtonDown("Jump"))
        {
            _isJumping = true;
            _jumpCounter = _jumpTime;
            _rigidBody2D.velocity = Vector2.up * _jumpHeight;
        }

        if (Input.GetButtonDown("Jump") && _isJumping == true)
        {
            if (_jumpCounter > 0)
            {
                _rigidBody2D.velocity = Vector2.up * _jumpHeight;
                _jumpCounter -= Time.deltaTime;
            }
            else 
            {
                _isJumping = false;
            }
            
        }

        if (Input.GetButtonUp("Jump"))
        {
            _isJumping = false;
        }*/
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (_isGrounded == true && context.performed)
        {
            _isJumping = true;
            _jumpCounter = _jumpTime;
            _rigidBody2D.velocity = Vector2.up * _jumpHeight;
        }

        if (context.performed && _isJumping == true)
        {
            if (_jumpCounter > 0)
            {
                _rigidBody2D.velocity = Vector2.up * _jumpHeight;
                _jumpCounter -= Time.deltaTime;
            }
            else
            {
                _isJumping = false;
            }

        }

        if (context.canceled)   
        {
            _isJumping = false;
        }
    }

    public void PlayerIsDeath()
    {
        _isDeath = true;
        LevelManager.Instance.Restart();
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
