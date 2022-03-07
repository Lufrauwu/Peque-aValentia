using UnityEngine;

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
    private bool _facingRigth = true;
 
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        if (_isDeath)
        {
            return;
        }
        _horizontalMove = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(_horizontalMove, 0, 0) * Time.deltaTime * _walkSpeed;
        if (_horizontalMove < 0 &&_facingRigth)
        {
            Flip();
        }
        else if (_horizontalMove > 0 && !_facingRigth)
        {
            Flip();
        }
        _isGrounded = Physics2D.OverlapCircle(_feetTransform.position, _checkRadius, _groundLayer);
        if (_isGrounded == true && Input.GetButtonDown("Jump"))
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
        }
    }

    public void PlayerIsDeath()
    {
        _isDeath = true;
        LevelManager.instance.Restart();
    }

    private void Flip()
    {
        _facingRigth = !_facingRigth;
        transform.Rotate(0f, 180f, 0f);
    }
}
