using UnityEngine;
using UnityEngine.UI;

public class ImageContent : PoolableObject
{
    [Header("Elements")]
    [SerializeField] Image image;

    public void ApplyImage(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
