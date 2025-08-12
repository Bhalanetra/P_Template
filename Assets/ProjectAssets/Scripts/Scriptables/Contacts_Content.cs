using UnityEngine;

[CreateAssetMenu(fileName = "Contacts_Content", menuName = "P-Template/Content/Contacts_Content")]
public class Contacts_Content : ContentBase
{
    public ContactInfo[] contacts;

    #region Hidden Properties Region

    [ReadOnly, SerializeField, Space(10)]
    private ContentCategory type = ContentCategory.CONTACT_INFO;

    /// <summary>
    /// Public property to Get Screen Type.
    /// </summary>
    public override ContentCategory contentType => type;

    #endregion Hidden Properties Region
}
