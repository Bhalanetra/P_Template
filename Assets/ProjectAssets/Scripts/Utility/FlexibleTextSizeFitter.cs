using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(RectTransform))]
public class FlexibleTextSizeFitter : MonoBehaviour
{
    public enum FitMode { Unconstrained, PreferredSize }

    [SerializeField] private TMP_Text targetText;
    [SerializeField] private FitMode horizontalFit = FitMode.PreferredSize;
    [SerializeField] private FitMode verticalFit = FitMode.PreferredSize;
    [SerializeField] private Vector2 padding;

    private RectTransform rectTransform;
    private string lastText;
    private Vector2 lastSize;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        if (targetText == null) targetText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (targetText == null) return;

        // Detect text or size changes to avoid constant updates
        if (targetText.text != lastText || rectTransform.sizeDelta != lastSize)
        {
            lastText = targetText.text;
            UpdateSize();
        }
    }

    private void UpdateSize()
    {
        Vector2 newSize = rectTransform.sizeDelta;

        if (horizontalFit == FitMode.PreferredSize)
            newSize.x = targetText.preferredWidth + padding.x;

        if (verticalFit == FitMode.PreferredSize)
            newSize.y = targetText.preferredHeight + padding.y;

        rectTransform.sizeDelta = newSize;
        lastSize = newSize;
    }
}
