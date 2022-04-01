using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Enemy : MonoBehaviour
{
    public float health { get; private set; } = 3;
    public UnityEvent OnDeathEvent { get; private set; } = new UnityEvent();
    public UnityEvent OnHitEvent { get; private set; } = new UnityEvent();
    private float yMin = -1.5f;
    private void Start()
    {
        SetRigidbodyKinematic(true);
        SetColliderEnablement(false);
    }
    private void Update()
    {
        if (health == 0)
        {
            Death();
        }
        if (gameObject.transform.position.y < yMin)
        {
            Destroy(gameObject);
        }
    }
    public void Damage()
    {
        OnHitEvent.Invoke();
        if (health != 0)
            health--;
    }
    private void Death()
    {
        OnDeathEvent.Invoke();
        SetRigidbodyKinematic(false);
        SetColliderEnablement(true);
    }
    private void SetRigidbodyKinematic(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rg in rigidbodies)
        {
            rg.isKinematic = state;
        }
        GetComponent<Rigidbody>().isKinematic = !state;
    }
    private void SetColliderEnablement(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider cr in colliders)
        {
            cr.enabled = state;
        }
        GetComponent<Collider>().enabled = !state;
    }
    private void OnDestroy()
    {
        OnHitEvent.RemoveAllListeners();
        OnDeathEvent.RemoveAllListeners();
    }
}
