using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _offset;
    [Range(0.01f, 1.0f)]
    [SerializeField] float _smoothFactor = 0.5f;

    private void Start()
    {
        _offset = transform.position - _player.position;
    }
    private void LateUpdate()
    {
        Vector3 newPos = _player.position + _offset;
        transform.position = Vector3.Slerp(transform.position, newPos, _smoothFactor);
    }
}
