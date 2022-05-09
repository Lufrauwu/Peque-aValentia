using UnityEngine;
using UnityEngine.InputSystem;

public class FireBullet : MonoBehaviour
{
    [SerializeField] private Transform _firePoint = default;
    [SerializeField] private GameObject _bulletPrefab = default;
    private PlayerController _playerController = default;
    private InputAction _inputShoot = default;
    private bool _shootEnable = true;

    private void Start()
    {
        _playerController = new PlayerController();
        _playerController.Enable();
        _inputShoot = _playerController.Land.Fire;
        _inputShoot.Enable();
        _playerController.Land.Fire.performed += _ => Shoot();
    }
    
    public void Activate()
    {
        _inputShoot.Enable();
    }

    public void Deactivate()
    {
        _inputShoot.Disable();

    }

    private void OnDestroy()
    {
        _playerController.Disable();
        _inputShoot.Disable();
    }

    private void Shoot()
    {
        if (!_shootEnable)
        {
            return;
        }
        Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
    }

    public void ToggleActivation()
    {
        _shootEnable = !_shootEnable;
        Debug.Log("FireBullet activado: " + _shootEnable);
        
    }

}
