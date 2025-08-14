using UnityEngine;

public static class RectTransformExtensions
{
    /// <summary>
    /// Sets the local X and Y position of a RectTransform relative to its parent,
    /// keeping Z unchanged.
    /// </summary>
    public static void SetLocalXY(this RectTransform rect, float x, float y)
    {
        if (rect == null) return;

        Vector3 localPos = rect.localPosition;
        localPos.x = x;
        localPos.y = y;
        rect.localPosition = localPos;
    }
}
