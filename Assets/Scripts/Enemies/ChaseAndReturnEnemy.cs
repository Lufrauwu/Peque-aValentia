using System.Collections;
using UnityEngine;

public class ChaseAndReturnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _player = default;
    [SerializeField] private float _distance = default;
    [SerializeField] private float _speedEnemy = default;
    [SerializeField] private float _enemyHealth = default;
    [SerializeField] private Vector2 _xVelocity = default;
    private Animator _flyAnimator = default;
    private Transform _playerPosition = default;
    private Vector2 _currentPosition = default;

    void Start()
    {
        _playerPosition = _player.GetComponent<Transform>();
        _currentPosition = GetComponent<Transform>().position;
        _flyAnimator = GetComponent<Animator>();
    }
    
    void Update()
    {
        _xVelocity.x = transform.position.x;
        _flyAnimator.Play("Flyingbug animation");
        if (Vector2.Distance(transform.position, _playerPosition.position) < _distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, _playerPosition.position, _speedEnemy * Time.deltaTime);
        }
        else
        {
            if (Vector2.Distance(transform.position, _currentPosition) <= 0)
            {
                
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, _currentPosition, _speedEnemy * Time.deltaTime);
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
    
    public IEnumerator FreezeCR()
    {
        Debug.Log("FREEZE");
        _speedEnemy = 0;
        gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        yield return new WaitForSeconds(3.0f);
        _speedEnemy = 24.4f;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Burn());
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
