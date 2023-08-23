using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpHeight = default;
    [SerializeField] private float _walkSpeed = default;
    [SerializeField] private float _checkRadius = default;
    [SerializeField] private float _jumpTime = default;
    [SerializeField] private Transform _feetTransform = default;
    [SerializeField] private LayerMask _groundLayer = default;
    [SerializeField] private Animator _playerAnimator = default;
    [SerializeField] private GameObject _spikes = default;
    [SerializeField] private float _fallMultiplier = default;
    Rigidbody2D _rigidBody2D = default;
    private Vector3 _respawnPoint = default;
    private float _jumpCounter = default;
    private float _horizontalMove = default;
    private bool _isGrounded = true;
    private bool _isJumping = default;
    private bool _isDeath = false;
    private bool _facingRight = true;
    private PlayerController _playerController = default;
    private InputAction _inputMove = default;
    private InputAction _inputJump = default;

    private void Awake()
    {
        _playerController = new PlayerController();
        _playerController.Enable();
        _inputMove = _playerController.Land.Move;
        _inputMove.Enable();
        _inputJump = _playerController.Land.Jump;
        _inputJump.Enable();
        _inputJump.started += Jump;
        _inputJump.canceled += EndJump;
    }

    private void OnDestroy()
    {
        _inputMove.Disable();
        _inputJump.Disable();
        _playerController.Disable();
    }

    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _respawnPoint = transform.position;
    }

    void Update()
    {
        if (_isDeath)
        {
            return;
        }
        if (PauseManager._paused)
        {
            return;
        }
        _horizontalMove = _inputMove.ReadValue<float>();
        Vector3 currentPosition = transform.position;
        currentPosition.x += _horizontalMove * _walkSpeed * Time.deltaTime;
        transform.position = currentPosition;
        _playerAnimator.SetFloat("Speed", _horizontalMove);
        /*if (_horizontalMove > 0 && _facingRight)
        {
            _playerAnimator.SetBool("Right", true);
          // _playerAnimator.SetBool("IsMoving", true);
        }
        else if (_horizontalMove < 0 && !_facingRight)
        {
            _playerAnimator.SetBool("Right", false);
           // _playerAnimator.SetBool("IsMoving", true);
        }*/
        if (_isGrounded)
        {
            CheckDirection();
        }
        if (_horizontalMove < 0 && _facingRight)
        {
            Flip();
        }
        else if (_horizontalMove > 0 && !_facingRight)
        {
            Flip();
        }
        if (_horizontalMove == 0)
        {
            _playerAnimator.SetBool("IsMoving", false);
        }
        _playerAnimator.SetBool("IsGrounded", _isGrounded);
        _playerAnimator.SetBool("IsJumping", !_isGrounded);
        _isGrounded = Physics2D.OverlapCircle(_feetTransform.position, _checkRadius, _groundLayer);
    }

    private void CheckDirection()
    {
        if (_horizontalMove > 0 && _facingRight)
        {
            _playerAnimator.SetBool("Right", true);
            _playerAnimator.SetBool("IsMoving", true);
        }
        else if (_horizontalMove < 0 && !_facingRight)
        {
            _playerAnimator.SetBool("Right", false);
            _playerAnimator.SetBool("IsMoving", true);
        }
    }
    private void Jump(InputAction.CallbackContext context)
    {
        if (_isGrounded == true)
        {

            _isJumping = true;
            _jumpCounter = _jumpTime;
            // _rigidBody2D.velocity += Vector2.up * Physics2D.gravity.y * _fallMultiplier  * Time.deltaTime;
            _rigidBody2D.velocity = Vector2.up * _jumpHeight;
            //_rigidBody2D.AddForce(Vector2.up * _jumpHeight * Time.deltaTime , ForceMode2D.Impulse);
        }
        if (_horizontalMove > 0 && _facingRight)
        {
            _playerAnimator.SetBool("Right", true);
            // _playerAnimator.SetBool("IsMoving", true);
        }
        else if (_horizontalMove < 0 && !_facingRight)
        {
            _playerAnimator.SetBool("Right", false);
            // _playerAnimator.SetBool("IsMoving", true);
        }

        if (_isJumping == true)
        {
            if (_jumpCounter > 0)
            {
                //_rigidBody2D.velocity += Vector2.up * Physics2D.gravity.y * _fallMultiplier  * Time.deltaTime;
                _rigidBody2D.velocity = Vector2.up * _jumpHeight;
                //_rigidBody2D.AddForce(Vector2.up * _jumpHeight * Time.deltaTime, ForceMode2D.Impulse);
                _jumpCounter -= Time.deltaTime;
            }
            else
            {
                _isJumping = false;
            }
        }
    }

    private void EndJump(InputAction.CallbackContext context)
    {
        _isJumping = false;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spikes"))
        {
            transform.position = _respawnPoint;
        }
        else if (collision.CompareTag("Checkpoint"))
        {
            _respawnPoint = transform.position;
            Debug.Log("CHECKPOINT");
        }
    }
}
