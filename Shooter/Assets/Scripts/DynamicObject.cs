using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DynamicObject : MonoBehaviour
{
    [SerializeField] private ParticleSystem _objectDamageParticle;
    private float yMin = -1.5f;
    private Rigidbody _rb;
    private void Start()
    {
        _objectDamageParticle = GetComponentInChildren<ParticleSystem>();
        _objectDamageParticle.Stop();
        _rb = gameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (gameObject.transform.position.y < yMin)
        {
            Destroy(gameObject);
        }
    }
    public void Damage(Vector3 direction, float bulletSpeed)
    {
        _rb.AddForce((direction).normalized * bulletSpeed, ForceMode.Impulse);
        _objectDamageParticle.Play();
    }
}
