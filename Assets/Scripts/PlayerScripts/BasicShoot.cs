using UnityEngine;

public class BasicShoot : MonoBehaviour
{
    [SerializeField] private Transform _firePoint = default;
    [SerializeField] private GameObject _bulletPrefab = default;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    } 

    private void Shoot()
    {
        Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
    }
}
