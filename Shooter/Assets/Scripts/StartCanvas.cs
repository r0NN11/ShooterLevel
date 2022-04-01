using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(PlayerNavMesh))]
public class StartCanvas : MonoBehaviour
{
    private PlayerNavMesh _player;
    [SerializeField] private Canvas _startCanvas;

    void Start()
    {
        _player = GetComponent<PlayerNavMesh>();
        _startCanvas.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.start)
        {
            _startCanvas.enabled = false;
        }
    }
}
