using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Enemy))]
public class EnemyHealthBar : MonoBehaviour
{
    private Enemy _enemy;
    [SerializeField] private Slider _slider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;
    [SerializeField] private GameObject _healthbar;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _slider.value = _enemy.health;
        _fill.color = _gradient.Evaluate(1f);
        _enemy.OnHitEvent.AddListener(Hit);
        _enemy.OnDeathEvent.AddListener(Death);
    }
    private void Hit()
    {
        _healthbar.SetActive(true);
        _slider.value--;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
    private void Death()
    {
        _healthbar.SetActive(false);
    }
}
