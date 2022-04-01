using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;

    public bool hasEnemies()
    {
        if (enemies == null)
            return true;

        foreach (GameObject enemy in enemies)
            if (enemy.GetComponent<Enemy>().health != 0)
                return false;

        return true;
    }
}
