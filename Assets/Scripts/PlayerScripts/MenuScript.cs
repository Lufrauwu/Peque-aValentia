using UnityEngine;
using UnityEngine.InputSystem;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private Vector3 _mousePosition = default;
    [SerializeField] private GameObject _iceSpace = default;
    [SerializeField] private GameObject _fireSpace = default;
    [SerializeField] private GameObject _pieMenu = default;
    private PlayerController _playerController = default;
    private InputAction _inputSwitch = default;
    private float _halfWidth = default;

    private PowerType _lastSelected = default;

    void Start()
    {
        _inputSwitch = _playerController.Land.SwitchMagic;
        _inputSwitch.Enable();
    }

    void Update()
    {
        _mousePosition = Mouse.current.position.ReadValue();
         _halfWidth = Screen.width / 2f;
        Debug.Log(_mousePosition.x);


    }
    
    private void ShowMenu()
    {
       /* if (_playerController.Land.SwitchMagic.IsPressed())
        {

        }*/
        
           
        
        if (_mousePosition.x < _halfWidth)
        {
            _iceSpace.transform.localScale = Vector3.one * 1.1f;
            _fireSpace.transform.localScale = Vector3.one;
            _lastSelected = PowerType.Ice;
        }
        else
        {
            _fireSpace.transform.localScale = Vector3.one * 1.1f;
            _iceSpace.transform.localScale = Vector3.one;
            _lastSelected = PowerType.Fire;
        }
    }
}

public enum PowerType
{
    Fire,
    Ice
}
