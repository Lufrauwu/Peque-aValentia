using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeDimention : MonoBehaviour
{
    [SerializeField] private GameObject _dimention = default;
    private PlayerController _playerController = default;
    private InputAction _inputDimention = default;

    private void Awake()
    {
        _playerController = new PlayerController();
        _playerController.Enable();
        _inputDimention = _playerController.Land.ChangeDimention;
        _inputDimention.Enable();
        _inputDimention.started += _ => DimentionalChange();
    }

    private void OnDisable()
    {
        _playerController.Disable();
        _inputDimention.Disable();
    }

    private void DimentionalChange()
    {
        _dimention.SetActive(!_dimention.activeSelf);
    }

}

