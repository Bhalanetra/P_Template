using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    [SerializeField] Button resumeButton;

    private void Start()
    {
        resumeButton.onClick.AddListener(() =>
        {
            GoToResume();
        });
    }

    public void GoToResume()
    {
        PortfolioManager portfolioManager = PortfolioManager.Instance;

        if (UrlHelper.IsValidUrl(portfolioManager.CvUrl))
        {
            UrlHelper.OpenUrl(portfolioManager.CvUrl);
        }
    }
}
