using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Enemy))]
public class EnemyAnimation : MonoBehaviour
{
    private Enemy _enemy;
    private Animator _animator;
    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _animator = GetComponent<Animator>();
        _enemy.OnHitEvent.AddListener(Hit);
        _enemy.OnDeathEvent.AddListener(Death);
    }
    private void Hit()
    {
        _animator.SetTrigger("Hit");
    }
    private void Death()
    {
        _animator.enabled = false;
    }
}
