using UnityEngine;
using UnityEngine.UI;

public class ImageContent : PoolableObject
{
    [Header("Elements")]
    [SerializeField] Image image;

    public RectTransform self;

    private ProjectInfo_HUD myProjectInfoHUD;

    public void SetProjectHUD(ProjectInfo_HUD projectInfoHUD)
    {
        myProjectInfoHUD = projectInfoHUD;
    }

    public void ApplyImage(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
