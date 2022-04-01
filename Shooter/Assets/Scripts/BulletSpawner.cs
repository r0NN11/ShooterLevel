using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ShootControl))]
public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Transform _gunEnd;
    private ShootControl _shootControl;
    private void Start() 
    {
        _shootControl = GetComponent<ShootControl>();
    }
    public void Shoot()
    {
        RaycastHit hit;
        var pos = _shootControl.mousePos;
        var ray = Camera.main.ScreenPointToRay(new Vector3(pos.x, pos.y, 0));

        if (Physics.Raycast(ray, out hit))
        {
            var bullet = ObjectPooler.SharedInstance.GetPooledObject<Bullet>();
            if (bullet != null)
            {
                bullet.transform.position = _gunEnd.position;
                bullet.transform.rotation = _gunEnd.rotation;
                bullet.gameObject.SetActive(true);
                bullet.SetDirection(hit.point - bullet.transform.position);
            }


        }
    }
}
