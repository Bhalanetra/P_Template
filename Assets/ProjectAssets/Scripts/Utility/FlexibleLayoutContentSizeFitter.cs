using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[ExecuteAlways]
[RequireComponent(typeof(RectTransform))]
public class FlexibleLayoutContentSizeFitter : MonoBehaviour
{
    public enum FitMode { Unconstrained, PreferredSize }

    [SerializeField] private FitMode horizontalFit = FitMode.PreferredSize;
    [SerializeField] private FitMode verticalFit = FitMode.PreferredSize;
    [SerializeField] private Vector2 padding;
    [SerializeField] private bool includeInactive = false;

    private RectTransform rectTransform;
    private Vector2 lastSize;
    private readonly List<ILayoutElement> elements = new List<ILayoutElement>();

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        UpdateSizeIfNeeded();
    }

    private void UpdateSizeIfNeeded()
    {
        Vector2 preferred = CalculatePreferredSize();

        Vector2 newSize = rectTransform.sizeDelta;
        if (horizontalFit == FitMode.PreferredSize)
            newSize.x = preferred.x + padding.x;
        if (verticalFit == FitMode.PreferredSize)
            newSize.y = preferred.y + padding.y;

        if (newSize != lastSize)
        {
            rectTransform.sizeDelta = newSize;
            lastSize = newSize;
        }
    }

    //private Vector2 CalculatePreferredSize()
    //{
    //    elements.Clear();
    //    GetComponentsInChildren(includeInactive, elements);

    //    float maxWidth = 0f;
    //    float totalHeight = 0f;

    //    for (int i = 0; i < elements.Count; i++)
    //    {
    //        var e = elements[i];
    //        if (e is Behaviour b && !includeInactive && !b.gameObject.activeInHierarchy)
    //            continue;

    //        float prefWidth = e.preferredWidth >= 0 ? e.preferredWidth : 0f;
    //        float prefHeight = e.preferredHeight >= 0 ? e.preferredHeight : 0f;

    //        // For vertical stacking: width = max child width, height = sum
    //        maxWidth = Mathf.Max(maxWidth, prefWidth);
    //        totalHeight += prefHeight;
    //    }

    //    return new Vector2(maxWidth, totalHeight);
    //}

    private Vector2 CalculatePreferredSize()
    {
        var layoutGroup = GetComponent<LayoutGroup>();
        if (layoutGroup != null)
        {
            // Let Unity handle the child size + spacing
            return new Vector2(layoutGroup.preferredWidth, layoutGroup.preferredHeight);
        }

        elements.Clear();
        GetComponentsInChildren(includeInactive, elements);

        float maxWidth = 0f;
        float totalHeight = 0f;

        for (int i = 0; i < elements.Count; i++)
        {
            var e = elements[i];
            if (e is Behaviour b && !includeInactive && !b.gameObject.activeInHierarchy)
                continue;

            float prefWidth = e.preferredWidth >= 0 ? e.preferredWidth : 0f;
            float prefHeight = e.preferredHeight >= 0 ? e.preferredHeight : 0f;

            maxWidth = Mathf.Max(maxWidth, prefWidth);
            totalHeight += prefHeight;
        }

        return new Vector2(maxWidth, totalHeight);
    }
}
