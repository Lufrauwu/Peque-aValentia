using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D _rb2D;
    [SerializeField] private float _velocity = 10f;
    [SerializeField] private float _JumpH = 10f;  
    [SerializeField] Transform _feetPos;
    [SerializeField] float _checkRadius;
    [SerializeField] LayerMask _whatIsGrnd;
    [SerializeField] private float _jumptime;
    private bool _isGrounded=default;
    private bool _isJumping;
    private float _jumpCounter;
    

    void Start()
    {
        _rb2D=GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            gameObject.transform.Translate(-_velocity * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.D))
            gameObject.transform.Translate(_velocity * Time.deltaTime, 0, 0);

        _isGrounded = Physics2D.OverlapCircle(_feetPos.position, _checkRadius, _whatIsGrnd);
        if (_isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            _isJumping = true;
            _jumpCounter = _jumptime;
            _rb2D.velocity = Vector2.up * _JumpH;
        }
        if (Input.GetKey(KeyCode.Space) && _isJumping == true)
        {
            if (_jumpCounter > 0)
            {
                _rb2D.velocity = Vector2.up * _JumpH;
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
}
