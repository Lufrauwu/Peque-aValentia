using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnChange : MonoBehaviour
{
    [SerializeField] private Spikes _spikes;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _spikes.ChangeCheckPoint(transform.position);
        }
    }
}
