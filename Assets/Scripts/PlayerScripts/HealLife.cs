using UnityEngine;
using UnityEngine.InputSystem;

public class HealLife : MonoBehaviour
{

    [SerializeField] private HealthController healthController = default;
    private PlayerController _playerController = default;
    private InputAction _inputHeal = default;
    private int _healActions = 3;

    void Start()
    {
        _playerController = new PlayerController();
        _playerController.Enable();
        _inputHeal = _playerController.Land.Heal;
        _inputHeal.Enable();
        _inputHeal.started += _ => Healing();
    }

    private void OnDestroy()
    {
        _playerController.Disable();
        _inputHeal.Disable();
    }

    private void Healing()
    {
        if (_healActions > 0)
        {
            healthController.Heal();
        }
    }

    private void AddActionHeal()
    {
        if (_healActions > 3)
        {
            _healActions++; 
        }
    }
}

