using UnityEngine.InputSystem;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    [SerializeField] private GameObject _buttonPlayer = default;
    [SerializeField] private GameObject _cedarPlayer = default;

    private PlayerController _playerController = default;
    private InputAction _inputChange = default;
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
            _buttonPlayer.SetActive(false);
            _cedarPlayer.SetActive(true);
            _cedarPlayer.transform.position = _buttonPlayer.transform.position;
        }
        else
        {
            _cedarPlayer.SetActive(false);
            _buttonPlayer.SetActive(true);
            _buttonPlayer.transform.position = _cedarPlayer.transform.position;
        }
    }
}
