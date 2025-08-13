using UnityEngine;

public class Experiance_Container : ContentContainerBase
{
    [Space]
    [SerializeField] WorkExperience_Content experianceContent;
    [SerializeField] RectTransform contentParent;

    public override void InitializeContent(ContentBase content)
    {
        experianceContent = content as WorkExperience_Content;

        base.InitializeContent(content);
    }

    public override void ApplyContent()
    {
        foreach (WorkExperiance experiance in experianceContent.experiances)
        {
            PoolableObject poolObject = PoolManager.Instance.SpawnFromPool("Experiance_HUD", contentParent, Quaternion.identity);

            if(poolObject.TryGetComponent(out Experiance_HUD experianceHUD))
            {
                experianceHUD.ApplyContent(experiance);
            }
        }
    }
}
