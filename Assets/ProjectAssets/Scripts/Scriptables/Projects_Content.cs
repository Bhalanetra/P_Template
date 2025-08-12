using UnityEngine;

[CreateAssetMenu(fileName = "Projects_Content", menuName = "P-Template/Content/Projects_Content")]
public class Projects_Content : ContentBase
{
    public Project[] projects;

    #region Hidden Properties Region

    [ReadOnly, SerializeField, Space(10)]
    private ContentCategory type = ContentCategory.PROJECTS;

    /// <summary>
    /// Public property to Get Screen Type.
    /// </summary>
    public override ContentCategory contentType => type;

    #endregion Hidden Properties Region
}
