using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D _rigidBody2D = default;
    [SerializeField] private float _jumpHeight = default;  
    [SerializeField] Transform _feetTransform = default;
    [SerializeField] float _checkRadius = default;
    [SerializeField] LayerMask _groundLayer = default;
    [SerializeField] private float _jumpTime = default;
    private float _horizontalMove = default;
    private bool _isGrounded = default;
    private bool _isJumping = default;
    private bool _isDeath = false;
    private float _jumpCounter = default;
    

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
        _isGrounded = Physics2D.OverlapCircle(_feetTransform.position, _checkRadius, _groundLayer);
        if (_isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            _isJumping = true;
            _jumpCounter = _jumpTime;
            _rigidBody2D.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.Space) && _isJumping == true)
        {
            if (_jumpCounter > 0)
            {
                _rigidBody2D.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Force);
                _jumpCounter -= Time.deltaTime;
            }
            else 
            {
                _isJumping = false;
            }
            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        // controller.
    }

    private void Flip()
    {

    }

    public void PlayerIsDeath()
    {
        _isDeath = true;
        FindObjectOfType<LevelManager>().Restart();
    }
}

