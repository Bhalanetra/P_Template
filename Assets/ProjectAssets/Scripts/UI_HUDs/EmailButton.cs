using UnityEngine;
using UnityEngine.UI;

public class EmailButton : MonoBehaviour
{
    [SerializeField] Button mailButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mailButton.onClick.AddListener(() =>
        {
            OpenMailBox();
        });
    }

    void OpenMailBox()
    {
        UrlHelper.ComposeEmail(PortfolioManager.Instance.Email, webMailService: UrlHelper.WebMailService.Gmail);
    }
}
