using UnityEngine;

[CreateAssetMenu(fileName = "Qualification_Content", menuName = "P-Template/Content/Qualification_Content")]
public class Qualifications_Content : ContentBase
{
    public Qualification[] qualifications;

    #region Hidden Properties Region

    [ReadOnly, SerializeField, Space(10)]
    private ContentCategory type = ContentCategory.QUALIFICATION;

    /// <summary>
    /// Public property to Get Screen Type.
    /// </summary>
    public override ContentCategory contentType => type;

    #endregion Hidden Properties Region
}
