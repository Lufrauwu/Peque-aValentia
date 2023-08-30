using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour
{
    private bool _movingRight = true;
    private float _rayDistance = 2.0f;
    [SerializeField] private Transform _groundCheck = default;
    [SerializeField] private int _enemyHealth = 10;
    [SerializeField] private float _walkSpeed = 10;
    [SerializeField] private Animator _enemyAnimator = default;
    [SerializeField] private float _knockBackForceX = default;
    [SerializeField] private float _knockBackForceY = default;
    [SerializeField] private Rigidbody2D _rigidbody2D = default;

    private void Awake()
    {
        _enemyAnimator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _enemyAnimator.Play("Walk_Bug");
        transform.Translate(Vector2.right * _walkSpeed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(_groundCheck.position, Vector2.down, _rayDistance);
        if (groundInfo.collider == false)
        {
            if (_movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                _movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                _movingRight = true;
            }
        }
    }

    public void TakeDamage(int _damageRecived)
    {
        _enemyHealth -= _damageRecived;
        if (_enemyHealth <= 0)
        {
            Die();
        }
    }

    public void KnockBackImpulse(GameObject col)
    {
        Vector2 knockbackForce = col.transform.position.x > transform.position.x ? new Vector2(-_knockBackForceX, _knockBackForceY)  : new Vector2(_knockBackForceX, _knockBackForceY);
        _rigidbody2D.AddForce(knockbackForce, ForceMode2D.Force);
        Debug.Log(knockbackForce);
        Debug.Log("salio volando");
    }

    public IEnumerator FreezeBE()
    {
        _walkSpeed = 0;
        _enemyAnimator.gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        yield return new WaitForSeconds(3.0f);
        _walkSpeed = 10;
        _enemyAnimator.gameObject.GetComponent<Animator>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Firebullet"))
        {
            StartCoroutine(Burn());
        }
    }
    public IEnumerator Burn()
    {
        int burnDamage = -1;
        yield return new WaitForSeconds(.2f);
        _enemyHealth = _enemyHealth + burnDamage;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(.2f);
        _enemyHealth = _enemyHealth + burnDamage;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.2f);
        _enemyHealth = _enemyHealth + burnDamage;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}


