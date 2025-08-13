using System;
using UnityEngine;

[Serializable]
public class PoolData
{
    public string Id;
    public PoolableObject Prefab;
    public int DefaultCapacity;
    public int MaxSize;
}

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }

    public PoolData[] _poolData;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        foreach(PoolData data in _poolData)
        {
            InitializePool(data.Id, data.Prefab, data.DefaultCapacity, data.MaxSize);
        }
    }

    public void InitializePool(string key, PoolableObject prefab, int defaultCapacity = 10, int maxSize = 100)
    {
        ObjectPoolManager.Instance.CreatePool(key, prefab, defaultCapacity, maxSize);
    }

    public PoolableObject SpawnFromPool(string key, Vector3 position, Quaternion rotation)
    {
        PoolableObject obj = ObjectPoolManager.Instance.GetObject(key);
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        return obj;
    }

    public PoolableObject SpawnFromPool(string key, Transform transform, Quaternion rotation)
    {
        PoolableObject obj = ObjectPoolManager.Instance.GetObject(key);
        obj.transform.SetParent(transform);
        obj.transform.rotation = rotation;
        return obj;
    }
    public PoolableObject SpawnFromPool(string key, RectTransform transform, Quaternion rotation)
    {
        PoolableObject obj = ObjectPoolManager.Instance.GetObject(key);
        obj.transform.SetParent(transform);
        obj.transform.localScale = Vector3.one;
        obj.transform.rotation = rotation;
        return obj;
    }

    public void ReturnToPool(string key, PoolableObject obj)
    {
        ObjectPoolManager.Instance.ReleaseObject(key, obj);
    }
}
