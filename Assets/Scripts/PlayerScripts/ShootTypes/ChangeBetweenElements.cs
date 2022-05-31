using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeBetweenElements : MonoBehaviour
{
    private PlayerController _playerController = default;
    private IceBeam _iceBeam = default;
    private FireBullet _fireBullet = default;
    private InputAction _inputSwitch = default;

    private void Awake()
    {
        /*_playerController = new PlayerController();
        _playerController.Enable();
        _inputSwitch = _playerController.Land.SwitchMagic;
        _inputSwitch.Enable();
        _inputSwitch.performed += _ => SwitchMagic();
    }

    private void OnDestroy()
    {
        _playerController.Disable();
        _inputSwitch.Disable();
    }

    void Start()
    {
        _iceBeam = GetComponent<IceBeam>();
        _fireBullet = GetComponent<FireBullet>();
    }


    void SwitchMagic()
    {
        _iceBeam.ToggleActivation();
        _fireBullet.ToggleActivation();
    }*/

}
