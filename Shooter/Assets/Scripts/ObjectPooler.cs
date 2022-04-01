using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject _tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            _tmp = Instantiate(objectToPool);
            _tmp.SetActive(false);
            pooledObjects.Add(_tmp);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                var _ret = pooledObjects[i];
                _ret.SetActive(true);
                return _ret;
            }
        }

        var _newObj = Instantiate(objectToPool);
        pooledObjects.Add(_newObj);
        return _newObj;
    }

    public T GetPooledObject<T>()
    {
        return GetPooledObject().GetComponent<T>();
    }


}
