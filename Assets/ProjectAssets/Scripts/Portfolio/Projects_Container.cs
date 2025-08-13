using UnityEngine;

public class Projects_Container : ContentContainerBase
{
    [Space]
    [SerializeField] Projects_Content projectContent;
    [SerializeField] RectTransform contentParent;
    public override void InitializeContent(ContentBase content)
    {
        projectContent = content as Projects_Content;

        base.InitializeContent(content);
    }

    public override void ApplyContent()
    {
        foreach (Project project in projectContent.projects)
        {
            PoolableObject poolObject = PoolManager.Instance.SpawnFromPool("Project_HUD", contentParent, Quaternion.identity);

            if(TryGetComponent(out ProjectInfo_HUD projectInfoHUD))
            {
                projectInfoHUD.ApplyContent(project);
            }
        }
    }
}
