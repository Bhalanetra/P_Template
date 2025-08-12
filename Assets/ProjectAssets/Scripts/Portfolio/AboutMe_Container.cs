using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AboutMe_Container : ContentContainerBase
{
    [Space]
    public AboutMe_Content content;

    [Space, Header("CONTAINER DETAILS")]
    [SerializeField] Image profileImage;
    [SerializeField] TextMeshProUGUI bioText;
    [SerializeField] TextMeshProUGUI tip;


    [Space, Header("DEFAULT SETTINGS")]
    public Sprite defaultIcon;

    public override void InitializeContent(ContentBase content)
    {
        this.content = content as AboutMe_Content;

        base.InitializeContent(content);
    }

    public override void ApplyContent()
    {
        if (content.profileImage != null) profileImage.sprite = content.profileImage;
        else profileImage.sprite = defaultIcon;

        if (!string.IsNullOrEmpty(content.shortBio))
        {
            bioText.text = content.shortBio;
            bioText.gameObject.SetActive(true);
        }

        if (!string.IsNullOrEmpty(content.tip))
        {
            tip.text = content.tip;
            tip.gameObject.SetActive(true);
        }
    }
}
