using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Vector3 _prevPos;
    [SerializeField] private float _bulletSpeed = 15f;
    private Rigidbody _rb;
    void Awake()
    {
        _prevPos = transform.position;
        _rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        RaycastHit[] hits = Physics.RaycastAll(_prevPos, (transform.position - _prevPos).normalized, (transform.position - _prevPos).magnitude);
        foreach (RaycastHit rh in hits)
        {
            gameObject.SetActive(false);
            if (rh.collider.gameObject.GetComponent<Enemy>())
            {
                Enemy _enemy = rh.collider.gameObject.GetComponent<Enemy>();
                _enemy.Damage();
            }
            else if (rh.collider.gameObject.GetComponent<DynamicObject>())
            {
                DynamicObject _dynamicObject = rh.collider.gameObject.GetComponent<DynamicObject>();
                _dynamicObject.Damage((transform.position - _prevPos), _bulletSpeed);
            }
        }
        _prevPos = transform.position;
    }
    public void SetDirection(Vector3 direction)
    {
        _rb.velocity = direction.normalized * _bulletSpeed;
    }

}
