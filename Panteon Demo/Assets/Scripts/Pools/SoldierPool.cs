using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierPool : MonoBehaviour
{
    /// <summary>
    /// ObjectPool Design Pattern
    /// We need to spawn soldiers in placed buildings
    /// but we didn't spawned everywhere. Firstly we created a soldier pool and assigned to three type soldier
    /// All soldiers created a prefabs so we can use directly in the Pool Struct and also prefered Queue instead of Array
    /// </summary>
    [Serializable]
    struct Pool
    {
        public Queue<GameObject> pooledSoldiers;
        public GameObject soldierPrefab;
        public int poolSize;
    }

    public static SoldierPool Instance;

    [SerializeField] private Pool[] pools = null;

    private int _pooledObjectCounter;

    public int PooledObjectcounter => _pooledObjectCounter;
    private void Awake()  /// Create a soldier pool
    {
        Instance = this;

        for (int j = 0; j < pools.Length; j++)
        {
            pools[j].pooledSoldiers = new Queue<GameObject>();

            for (int i = 0; i < pools[j].poolSize; i++)
            {
                GameObject obj = Instantiate(pools[j].soldierPrefab);

                obj.SetActive(false);

                pools[j].pooledSoldiers.Enqueue(obj);

                _pooledObjectCounter++;
            }
        }

    }

    public GameObject GetPooledObject(int objectType)   /// Get soldiers from pool
    {
        if (objectType >= pools.Length)
        {
            return null;
        }

        GameObject obj = pools[objectType].pooledSoldiers.Dequeue();

        obj.SetActive(true);

        pools[objectType].pooledSoldiers.Enqueue(obj);

        return obj;
    }
}
