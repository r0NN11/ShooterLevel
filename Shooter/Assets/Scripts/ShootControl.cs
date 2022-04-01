using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(PlayerNavMesh))]
public class ShootControl : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    private Camera _cam;
    [SerializeField] private ParticleSystem _shootParticle;
    private PlayerNavMesh _player;
    public UnityEvent OnShootEvent { get; private set; } = new UnityEvent();
    public Vector3 mousePos { get; private set; }
    private void Start()
    {
        _player = GetComponent<PlayerNavMesh>();
        _cam = Camera.main;
        _shootParticle = GetComponentInChildren<ParticleSystem>();
        _shootParticle?.Stop();
        _player.OnIdleEvent.AddListener(Shoot);
    }

    private void Shoot()
    {
        if (_player.start)
        {
            RotateToMousePos();
            if (Input.GetMouseButtonDown(0))
            {
                _bulletSpawner.Shoot();
                _shootParticle.Play();
                OnShootEvent.Invoke();
            }
        }
    }
    private void RotateToMousePos()
    {
        mousePos = Input.mousePosition;
        Ray ray = _cam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(hit.point);
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
        }

    }
    private void OnDestroy()
    {
        OnShootEvent.RemoveAllListeners();
    }
}
