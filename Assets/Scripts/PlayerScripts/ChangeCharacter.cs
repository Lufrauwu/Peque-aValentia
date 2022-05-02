using UnityEngine.InputSystem;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    [SerializeField] private GameObject _currentPlayer = default;
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
    
    private void OnDisable()
    {
        _playerController.Disable();
        _inputChange.Disable();
    }

    private void PlayerChange()
    {
        _currentPlayer.SetActive(!_currentPlayer.activeSelf);
    }
}
