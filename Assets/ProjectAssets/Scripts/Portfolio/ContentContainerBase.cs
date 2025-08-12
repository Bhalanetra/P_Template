using UnityEngine;

public class ContentContainerBase : MonoBehaviour
{
    [Header("BASE SETTINGS")]
    public GameObject container;

    public virtual void InitializeContent(ContentBase content)
    {
        ApplyContent();
        EnableContainer();
    }

    public virtual void EnableContainer()
    {
        container.SetActive(true);
    }

    public virtual void ApplyContent() {}
}
