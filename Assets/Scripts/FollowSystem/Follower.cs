using UnityEngine;
using System.Linq;

public class Follower : MonoBehaviour
{
    [SerializeField] private FollowerMaster _master = null;
    [SerializeField] private float _speed = 0.1f;

    private Vector3 _currentDestination = default;

    private void Start()
    {
        _currentDestination = transform.position;
    }

    private void Update()
    {
        MoveToDestination();
        TryChangeDestination();
    }

    private void TryChangeDestination()
    {
        if (_master.Positions.Length == 0) return;

        var lastPosition = _master.Positions.First();

        if (lastPosition == _currentDestination) return;

        _currentDestination = lastPosition;
    }

    private void MoveToDestination()
    {
        var newPosition = Vector3.Lerp(transform.position, _currentDestination, _speed);
        transform.position = newPosition;
    }
}

