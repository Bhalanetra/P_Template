using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Contact_HUD : PoolableObject
{
    [Header("ELEMENTS")]
    [SerializeField] Image _icon;
    [SerializeField] TextMeshProUGUI socialNameText;
    [SerializeField] Button socialButton;

    private string url;

    public void ApplyContent(ContactInfo contactInfo)
    {
        _icon.sprite = contactInfo.socialIcon;
        socialNameText.text = contactInfo.socialName;

        if(!string.IsNullOrEmpty(contactInfo.contactUrl) && UrlHelper.IsValidUrl(contactInfo.contactUrl))
        {
            url = contactInfo.contactUrl;

            socialButton.onClick.AddListener(() =>
            {
                UrlHelper.OpenUrl(url);
            });
        }
    }
}
