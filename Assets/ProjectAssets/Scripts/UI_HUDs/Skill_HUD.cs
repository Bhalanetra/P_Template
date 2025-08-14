
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Skill_HUD : PoolableObject, IPointerEnterHandler, IPointerExitHandler
{
    [Header("ELEMENTS")]
    [SerializeField] Image _icon;
    [SerializeField] TextMeshProUGUI skillNameText;

    [Space]
    [SerializeField] RectTransform subSkillPanel;
    [SerializeField] RectTransform subSkillParent;

    [Space, Header("SUBSKILL PANEL SETTINGS")]
    public Vector2 idlePoint;
    public Vector2 hoverPoint;
    public Vector2 openedPoint;
    public float duration = 0.3f;

    [Space]
    public Button openButton;
    public Button closeButton;

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

    public void MoveChildRect(RectTransform child, Vector2 from, Vector2 to, float duration, Ease ease = Ease.OutQuad)
    {
        if (child == null)
        {
            Debug.LogWarning("MoveChildRect called with null child.");
            return;
        }

        // Start from given position
        child.anchoredPosition = from;

        // Move to target position
        child.DOAnchorPos(to, duration).SetEase(ease);
    }

    public void OpenSubSkills(bool open)
    {
        Vector2 targetPoint = open ? openedPoint : idlePoint;

        MoveChildRect(subSkillPanel, subSkillPanel.anchoredPosition, targetPoint, duration);

        if (open)
        {
            openButton.gameObject.SetActive(false);
            closeButton.gameObject.SetActive(true);
        }
        else
        {
            openButton.gameObject.SetActive(true);
            closeButton.gameObject.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MoveChildRect(subSkillPanel, subSkillPanel.anchoredPosition, hoverPoint, duration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OpenSubSkills(false);
    }
}
