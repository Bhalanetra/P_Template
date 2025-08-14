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

            if(poolObject.TryGetComponent(out ProjectInfo_HUD projectInfoHUD))
            {
                Debug.Log($"Found Project Info HUD and Passing Project : {project.projectName}");
                projectInfoHUD.ApplyContent(project);
            }
        }
    }
}
