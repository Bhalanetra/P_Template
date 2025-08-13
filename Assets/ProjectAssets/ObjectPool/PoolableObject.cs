using UnityEngine;

public class PoolableObject : MonoBehaviour, IPoolableObject
{
    [Header("POOL ID")]
    public string poolID;
    public bool isInPool = true;

    public virtual void ReturnToPool()
    {
        if (isInPool)
        {
            Debug.Log("Object Already In Pool");
            return;
        }

        isInPool = true;
        PoolManager.Instance.ReturnToPool(poolID, this);
    }

    public void OnGet()
    {
        isInPool = false;
        gameObject.SetActive(true);    
    }

    public void OnRelease()
    {
        gameObject.SetActive(false);
    }
}
