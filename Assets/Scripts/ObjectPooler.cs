using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstace;
    public List<GameObject> pooledObjects;
    public List<GameObject> objectToPools;
    public List<int> amountToPools;

    void Awake()
    {
        SharedInstace = this;
    }

    void Start()
    {
        GeneratePool();
    }

    private void GeneratePool()
    {
        pooledObjects = new List<GameObject>();
        for (int index = 0; index < objectToPools.Count; index++)
        {
            GameObject objectToPool = objectToPools[index];
            int amountToPool = amountToPools[index];

            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(objectToPool);
                pooledObjects.Add(obj);
                obj.transform.SetParent(transform);
            }
        }

        pooledObjects = pooledObjects.OrderBy(a => Guid.NewGuid()).ToList();
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        return null;
    }
}
