using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance { get; private set; }

    private Dictionary<string, IObjectPool<PoolableObject>> _pools;       

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            _pools = new Dictionary<string, IObjectPool<PoolableObject>>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CreatePool(string key, PoolableObject prefab, int defaultCapacity = 10, int maxSize = 100)
    {
        if (!_pools.ContainsKey(key))
        {
            IObjectPool<PoolableObject> pool = new ObjectPool<PoolableObject>(
                createFunc: () => Instantiate((prefab)),
                actionOnGet: obj => obj.OnGet(),
                actionOnRelease: obj => obj.OnRelease(),
                actionOnDestroy: obj => Destroy(obj.gameObject),
                collectionCheck: true,
                defaultCapacity: defaultCapacity,
                maxSize: maxSize
            );

            _pools[key] = pool;
        }
    }

    public PoolableObject GetObject(string key)
    {
        if (_pools.ContainsKey(key))
        {
            return _pools[key].Get();
        }

        Debug.LogError($"Pool with key {key} does not exist.");
        return null;
    }

    public void ReleaseObject(string key, PoolableObject obj)
    {
        if (_pools.ContainsKey(key))
        {
            _pools[key].Release(obj);
        }
        else
        {
            Debug.LogError($"Pool with key {key} does not exist.");
        }
    }
}
