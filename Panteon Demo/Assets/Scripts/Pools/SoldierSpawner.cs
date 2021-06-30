using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawner : Singleton<SoldierSpawner>
{
    /// <summary>
    /// Soldier spawner receive all soldiers in the pool but not active
    /// </summary>
    [SerializeField] private SoldierPool soldierPool = null;
    private int _objectCounter;    
    private int _soldierType;
    private GameObject _obj;
    public GameObject Obj => _obj;

    private int _minSoldierType = 0;
    private int _maxSoldierType = 3;

    [SerializeField] 
    private Vector3 inputPos;
    private Vector3 testpos;

    private void Start()
    {
        _objectCounter = soldierPool.PooledObjectcounter;
    }    

    public GameObject Spawn()  /// Get pooled soldiers
    {
        _soldierType = Random.Range(_minSoldierType, _maxSoldierType);

        _obj = soldierPool.GetPooledObject(_soldierType);

        _obj.transform.position = inputPos;

        _obj.transform.SetParent(transform);

        return Obj;
    }
}
