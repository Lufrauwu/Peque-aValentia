using UnityEngine;
using UnityEngine.InputSystem;

public class BasicShoot : MonoBehaviour
{
    [SerializeField] private Transform _firePoint = default;
    [SerializeField] private GameObject _bulletPrefab = default;
    private PlayerController _playerController = default;
    private InputAction _inputShoot = default;

    private void Awake()
    {
        _playerController = new PlayerController();
        _playerController.Enable();
        _inputShoot = _playerController.Land.Fire;
        _inputShoot.Enable();
        _playerController.Land.Fire.performed += _ => Shoot();
    }

    private void OnDestroy()
    {
        _playerController.Disable();
        _inputShoot.Disable();
    }

    private void Shoot()
    {          
        Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
    }
}
