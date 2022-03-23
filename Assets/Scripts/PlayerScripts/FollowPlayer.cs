using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float _maximumDuration = default;
    [SerializeField] private float _saveInterval = default;
    [SerializeField] private float _followSpeed = default;
    [SerializeField] private float _targetPosition = default;
    [SerializeField] private Transform _playerTransform = default;
    [SerializeField] private List<Vector3> _savedPositions = default;
    private Transform _targetTransform = default;
    private Rigidbody2D _rigidBody2D = default;
    private float _maximunSaved = default;

    void Start()
    {
        _maximunSaved = _maximumDuration / _saveInterval;
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _targetTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        TargetFollow();
        FlipFollower();
        SaveTransform();
    }

    void TargetFollow()
    {
        if (Vector2.Distance(transform.position, _targetTransform.position) > _targetPosition)
        {
            transform.position = Vector2.Lerp(transform.position, _savedPositions[5], _followSpeed * Time.deltaTime);
        }

    }

    void FlipFollower()
    {
        if (_playerTransform.position.x > transform.position.x)
        {
            transform.Rotate(0f, 0f, 0f);
        }
        else if (_playerTransform.position.x < transform.position.x)
        {
            transform.Rotate(0f, 180f, 0f);
        }
    }

    public void SaveTransform()
    {
        _savedPositions.Insert(0, _playerTransform.position);
        if (_savedPositions.Count > _maximunSaved)
        {
            _savedPositions.RemoveAt(_savedPositions.Count - 1);
        }
    }
}

