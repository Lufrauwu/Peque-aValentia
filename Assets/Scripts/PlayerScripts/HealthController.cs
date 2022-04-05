    using UnityEngine;
using UnityEngine.UI;
public class HealthController : MonoBehaviour
{
    [SerializeField] private int _playerHealth = default;
    [SerializeField] private int _healthNumber = default;
    [SerializeField] private Image[] _lifeContainer = default;
    [SerializeField] private Sprite _fullContainer = default;
    [SerializeField] private Sprite _emptyContainer = default;
    [SerializeField] private int _touchDamage = default;
    private PlayerMovement playerMovement = default;

    private void Awake()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        if (_playerHealth <= 0 )
        {
            playerMovement.PlayerIsDeath();
        }
        if (_playerHealth > _healthNumber)
        {
            _playerHealth = _healthNumber;
        }
        for (int i = 0; i < _lifeContainer.Length; i++)
        {
            if (i < _playerHealth)
            {
                _lifeContainer[i].sprite = _fullContainer;
            }
            else
            {
                _lifeContainer[i].sprite = _emptyContainer;
            }

            if (i < _healthNumber)
            {
                _lifeContainer[i].enabled = true;
            }
            else
            {
                _lifeContainer[i].enabled = false;
            }
        }
    }

    public void ReduceHealth()
    {
        _playerHealth -= _touchDamage;
        UpdateHealth();
    }
}
