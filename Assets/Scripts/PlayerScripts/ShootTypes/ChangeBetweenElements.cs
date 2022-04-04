using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeBetweenElements : MonoBehaviour
{
    private PlayerController _playerController = default;
    private IceBeam _iceBeam = default;
    private FireBullet _fireBullet = default;
    private InputAction _inputMove = default;

    private void Awake()
    {
        _playerController = new PlayerController();
        _playerController.Enable();
    }

    private void OnDisable()
    {
        _playerController.Disable();
    }

    void Start()
    {
        _iceBeam = GetComponent<IceBeam>();
        _fireBullet = GetComponent<FireBullet>();
    }


    void Update()
    {

    }
}
