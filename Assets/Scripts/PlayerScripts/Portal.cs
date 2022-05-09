using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject _darkDimention = default;
    [SerializeField] private GameObject _normalDimention = default;
    [SerializeField] TMP_Text _Interacttext = default;
    private bool _canInteract = default;
    private PlayerController _playerController = default;
    private InputAction _inputDimention = default;
    

    private void Start()
    {
        _playerController = new PlayerController();
        _playerController.Enable();
        _inputDimention = _playerController.Land.ChangeDimention;
        _inputDimention.Enable();
        _inputDimention.started += _ => ChangeDimention();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _Interacttext.gameObject.SetActive(true);
            _canInteract = true;
            Debug.Log("Entró");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _Interacttext.gameObject.SetActive(false);
            _canInteract = false;
        }
    }

    private void ChangeDimention()
    {
        if (_canInteract && _normalDimention.activeSelf)
        {
            _normalDimention.SetActive(false);
            _darkDimention.SetActive(true);
        }
        else if(_canInteract && _darkDimention.activeSelf)
        {
            _darkDimention.SetActive(false);
            _normalDimention.SetActive(true);
        }
    }
}
