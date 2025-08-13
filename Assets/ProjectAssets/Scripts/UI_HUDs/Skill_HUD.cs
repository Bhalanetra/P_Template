
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skill_HUD : PoolableObject
{
    [Header("ELEMENTS")]
    [SerializeField] Image _icon;
    [SerializeField] TextMeshProUGUI skillNameText;

    [Space]
    [SerializeField] RectTransform subSkillParent;

    public void ApplyContent(Skill skill)
    {
        _icon.sprite = skill.logo;
        skillNameText.text = skill.skillName;

        if(skill.subSkills != null && skill.subSkills.Length > 0)
        {
            foreach (SubSkill subSkill in skill.subSkills)
            {
                ApplySubSkillsData(subSkill);
            }
        }
    }

    void ApplySubSkillsData(SubSkill subSkill)
    {
        PoolableObject poolObject = PoolManager.Instance.SpawnFromPool("Subskill_HUD", subSkillParent, Quaternion.identity);

        if(poolObject.TryGetComponent(out SubSkill_HUD subSkillHUD))
        {
            subSkillHUD.ApplySubSkill(subSkill);
        }
    }
}
