using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class FollowerMaster : MonoBehaviour
{
    [SerializeField] private int _maxArrayLength = 10;

    private List<Vector3> positions = new List<Vector3>();

    public Vector3[] Positions => positions.ToArray();

    private void Update()
    {
        TryAddNewPosition(transform.position);
    }

    private void TryAddNewPosition(Vector3 newPosition)
    {
        //if (positions.Count > 0 && positions.Last() == newPosition) return;

        if (positions.Count == _maxArrayLength)
        {
            positions.RemoveAt(0);
        }

        positions.Add(newPosition);
    }
}

