using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubSkill_HUD : PoolableObject
{
    [Header("ELEMENTS")]
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI nameText;

    public void ApplySubSkill(SubSkill subSkill)
    {
        icon.sprite = subSkill.icon;
        nameText.text = subSkill.subSkillName;
    }
}
