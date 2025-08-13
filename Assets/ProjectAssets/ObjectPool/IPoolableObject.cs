using UnityEngine;

public interface IPoolableObject
{
    void OnGet();
    void OnRelease();
}
