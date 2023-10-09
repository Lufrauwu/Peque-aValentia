using System;
using UnityEngine.InputSystem;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    [SerializeField] private GameObject _buttonPlayer = default;
    [SerializeField] private GameObject _cedarPlayer = default;
    [SerializeField] private GameObject _buttonCamera = default;
    [SerializeField] private GameObject _ceddarCamera = default;
    [SerializeField] private GameObject _cedarLife = default;
    [SerializeField] private GameObject _buttonLife = default;
    private IceBeam iceBeam = default;
    private FireBullet fireBullet = default;
    private PlayerController _playerController = default;
    private InputAction _inputChange = default;

    private void Awake()
    {
        iceBeam = _cedarPlayer.GetComponent<IceBeam>();
        fireBullet = _cedarPlayer.GetComponent<FireBullet>();
    }

    void Start()
    {
        _playerController = new PlayerController();
        _playerController.Enable();
        _inputChange = _playerController.Land.ChangeCharacter;
        _inputChange.Enable();
        _inputChange.started += _ => PlayerChange();
    }

    private void OnDestroy()
    {
        _playerController.Disable();
        _inputChange.Disable();
    }

    private void PlayerChange()
    {
        if (_buttonPlayer.activeSelf)
        {
            _buttonCamera.SetActive(false);
            _buttonPlayer.SetActive(false);
            _buttonLife.SetActive(false);
            _ceddarCamera.SetActive(true);
            _cedarPlayer.SetActive(true);
            _cedarLife.SetActive(true);
            fireBullet.enabled = !fireBullet.enabled;
            iceBeam.enabled = !iceBeam.enabled;
            _cedarPlayer.transform.position = _buttonPlayer.transform.position;
        }
        else
        {
            _ceddarCamera.SetActive(false);
            _cedarPlayer.SetActive(false);
            _cedarLife.SetActive(false);
            fireBullet.enabled = !fireBullet.enabled;
            iceBeam.enabled = !iceBeam.enabled;
            _buttonCamera.SetActive(true);
            _buttonPlayer.SetActive(true);
            _buttonLife.SetActive(true);
            _buttonPlayer.transform.position = _cedarPlayer.transform.position;
        }
    }
}
