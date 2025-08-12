using UnityEngine;

[CreateAssetMenu(fileName = "Skill_Content", menuName = "P-Template/Content/Skill_Content")]
public class Skill_Content : ContentBase
{
    public Skill[] skills;

    #region Hidden Properties Region

    [ReadOnly, SerializeField, Space(10)]
    private ContentCategory type = ContentCategory.SKILLS;

    /// <summary>
    /// Public property to Get Screen Type.
    /// </summary>
    public override ContentCategory contentType => type;

    #endregion Hidden Properties Region
}
