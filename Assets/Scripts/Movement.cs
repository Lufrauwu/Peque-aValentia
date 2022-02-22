using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _velocity = 10f;
    [SerializeField] private float _jumpH = 4f;
    Rigidbody2D _rb2D;

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
        if (Input.GetKeyDown(KeyCode.Space))
           _rb2D.AddForce(new Vector2(0, _jumpH), ForceMode2D.Impulse);

    }
}
