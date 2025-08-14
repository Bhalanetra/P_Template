using UnityEngine;

public class Skills_Container : ContentContainerBase
{
    [Space]
    [SerializeField] Skill_Content skill_Content;
    [SerializeField] RectTransform contentParent;

    public override void InitializeContent(ContentBase content)
    {
        skill_Content = content as Skill_Content;

        base.InitializeContent(content);
    }

    public override void ApplyContent()
    {
        foreach (Skill skill in skill_Content.skills)
        {
            PoolableObject poolObject = PoolManager.Instance.SpawnFromPool("Skill_hud", contentParent, Quaternion.identity);

            if(poolObject.TryGetComponent(out Skill_HUD skillHUD))
            {
                skillHUD.ApplyContent(skill);
            }
        }
    }
}
