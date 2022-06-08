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

    private void Start()
    {
        _playerController = new PlayerController();
        _playerController.Enable();
        _inputShoot = _playerController.Land.Fire;
        _inputShoot.Enable();
        _playerController.Land.Fire.performed += _ => StartCoroutine(Shoot());

        Deactivate();
    }

    IEnumerator Shoot()
    {
        RaycastHit2D _hitInfo = Physics2D.Raycast(_firePoint.position, _firePoint.right);
        if (_hitInfo)
        {
            Debug.Log(_hitInfo);
            ChaseAndReturnEnemy _chaseEnemy = _hitInfo.transform.GetComponent<ChaseAndReturnEnemy>();
            if (_chaseEnemy != null)
            {
                _chaseEnemy.TakeDamage(_damage);
                StartCoroutine(_chaseEnemy.FreezeCR());
                Debug.Log("HITED");

            }

            BasicEnemy _basicEnemy = _hitInfo.transform.GetComponent<BasicEnemy>();
            if (_basicEnemy != null)
            {
                _basicEnemy.TakeDamage(_damage);
                StartCoroutine(_basicEnemy.FreezeBE());


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

    public void Activate()
    {
        _inputShoot.Enable();
    }

    public void Deactivate()
    {
        _inputShoot.Disable();
    }
}
