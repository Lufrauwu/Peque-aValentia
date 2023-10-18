using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject _playerTarget = default;
    private float _targetPosX = default;
    private float _targetPosY = default;

    private float posX = default;
    private float posY = default;

    [SerializeField] private float _maxLeft = default;
    [SerializeField] private float _maxRight = default;
    [SerializeField] private float _maxHeight = default;
    [SerializeField] private float _minHeight = default;
    [SerializeField] private float _cameraSpeed = default;
    [SerializeField] private bool _switchOn = true;

    private void Awake()
    {
        posX = _targetPosX;
        posY = _targetPosY;
        transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -1), 1);
    }

    void MoveCamera()
    {
        if (_switchOn)
        {
            if (_playerTarget)
            {
                _targetPosX = _playerTarget.transform.position.x;
                _targetPosY = _playerTarget.transform.position.y;
                if (_targetPosX > _maxRight && _targetPosX < _maxLeft)
                {
                    posX = _targetPosX;
                }

                if (_targetPosY < _maxHeight && _targetPosY > _minHeight)
                {
                    posY = _targetPosY;
                }
            }
            transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -1), _cameraSpeed * Time.deltaTime);
        }
    }
    
    void Update()
    {
        MoveCamera();
    }
}
