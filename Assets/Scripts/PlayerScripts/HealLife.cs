using UnityEngine;
using UnityEngine.InputSystem;

public class HealLife : MonoBehaviour
{
    private HealthController healthController = default;
    private PlayerController _playerController = default;
    private InputAction _inputHeal = default;
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

    void Update()
    {
        
    }
    private void Healing()
    {
        healthController.Heal();
        Debug.Log("HOLI");
    }
}
