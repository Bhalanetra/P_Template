using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "AboutMe", menuName = "P-Template/Content/AboutMe_Content")]
public class AboutMe_Content : ContentBase
{
    public Sprite profileImage;
    public string shortBio;
    public string tip;

    #region Hidden Properties Region

    [ReadOnly, SerializeField, Space(10)]
    private ContentCategory type = ContentCategory.ABOUT_ME;

    /// <summary>
    /// Public property to Get Screen Type.
    /// </summary>
    public override ContentCategory contentType => type;

    #endregion Hidden Properties Region
}