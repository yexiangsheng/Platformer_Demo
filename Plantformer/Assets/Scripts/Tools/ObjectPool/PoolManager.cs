using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    [SerializeField] Pool<Component>[] gameObjectPools;

    private void Start()
    {
        Initialize(gameObjectPools);
    }

    //’˚¿ÌPool
    void Initialize(Pool<Component>[] pools)
    {
        foreach (Pool<Component> pool in pools)
        {
            Transform poolParent = new GameObject("Pool: " + pool.Factory.name).transform;
            poolParent.parent = transform;

            pool.Initialize(poolParent);
        }
    }


}
