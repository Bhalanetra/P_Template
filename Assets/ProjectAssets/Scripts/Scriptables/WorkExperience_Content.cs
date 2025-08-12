using UnityEngine;

[CreateAssetMenu(fileName = "WorkExperience_Content", menuName = "P-Template/Content/WorkExperience_Content")]
public class WorkExperience_Content : ContentBase
{
    public WorkExperiance[] experiances;

    #region Hidden Properties Region

    [ReadOnly, SerializeField, Space(10)]
    private ContentCategory type = ContentCategory.EXPERIENCE;

    /// <summary>
    /// Public property to Get Screen Type.
    /// </summary>
    public override ContentCategory contentType => type;

    #endregion Hidden Properties Region
}
