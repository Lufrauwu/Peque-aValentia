using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class IceBeam : MonoBehaviour
{
    [SerializeField] private Transform _firePoint = default;
    [SerializeField] private int _damage = default;
    [SerializeField] private LineRenderer _lineRenderer = default;
    private PlayerController _playerController = default;
    private InputAction _inputShoot = default;
    private bool _shootEnable = false;

    private void Start()
    {
        _playerController = new PlayerController();
        _playerController.Enable();
        _inputShoot = _playerController.Land.Fire;
        _inputShoot.Enable();
        _playerController.Land.Fire.performed += _ => StartCoroutine(Shoot());
    }                           

    IEnumerator Shoot()
    {
        if (!_shootEnable)
        {
            yield break;
        }
        RaycastHit2D _hitInfo = Physics2D.Raycast(_firePoint.position, _firePoint.right);
        if (_hitInfo)
        {
            BasicEnemy _enemy = _hitInfo.transform.GetComponent<BasicEnemy>();
            if (_enemy != null)
            {
                _enemy.TakeDamage(_damage);
                StartCoroutine(_enemy.Freeze());

            }
            _lineRenderer.SetPosition(0, _firePoint.position);
            _lineRenderer.SetPosition(1, _hitInfo.point);
        }
        else
        {
            _lineRenderer.SetPosition(0, _firePoint.position);
            _lineRenderer.SetPosition(1, _firePoint.position + _firePoint.right * 50);
        }
        _lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.2f);
        _lineRenderer.enabled = false;
    }

    public void ToggleActivation()
    {
        _shootEnable = !_shootEnable;
        Debug.Log("IceBeam activado: " + _shootEnable);
    }
}
