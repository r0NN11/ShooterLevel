using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerNavMesh))]
[RequireComponent(typeof(ShootControl))]
public class PlayerAnimations : MonoBehaviour
{
    private PlayerNavMesh _player;
    private ShootControl _shootControl;
    private Animator _animator;
    private void Start()
    {
        _player = GetComponent<PlayerNavMesh>();
        _shootControl = GetComponent<ShootControl>();
        _animator = GetComponent<Animator>();
        _player.OnRunEvent.AddListener(PlayerRun);
        _player.OnIdleEvent.AddListener(PlayerIdle);
        _shootControl.OnShootEvent.AddListener(PlayerShoot);
    }
    private void PlayerRun()
    {
        _animator.SetBool("Idle", false);

    }
    private void PlayerIdle()
    {
        _animator.SetBool("Idle", true);
    }
    private void PlayerShoot()
    {
        _animator.Play("Pistol idle", 0, 0);
    }

}
