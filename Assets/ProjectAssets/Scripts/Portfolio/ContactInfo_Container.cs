
using UnityEngine;

public class ContactInfo_Container : ContentContainerBase
{
    [Space]
    [SerializeField] Contacts_Content contacts;
    [SerializeField] RectTransform contentParent;

    public override void InitializeContent(ContentBase content)
    {
        contacts = content as Contacts_Content;

        base.InitializeContent(content);
    }


    public override void ApplyContent()
    {
        foreach (ContactInfo contact in contacts.contacts)
        {
            PoolableObject poolableObject = PoolManager.Instance.SpawnFromPool("Contact_HUD", contentParent, Quaternion.identity);

            if(poolableObject.TryGetComponent(out Contact_HUD contactHUD))
            {
                contactHUD.ApplyContent(contact);
            }
        }
    }
}
