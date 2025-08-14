using UnityEngine;
using UnityEngine.UI;

public class VideoContentAndPlayer : PoolableObject
{
    [Header("ELEMENTS")]
    [SerializeField] Image thumbnail;
    [SerializeField] Button playButton;

    public RectTransform self;

    [Space]
    [SerializeField] RectTransform contentParent;

    private ProjectInfo_HUD myProjectInfoHUD;

    public void SetProjectHUD(ProjectInfo_HUD projectInfoHUD)
    {
        myProjectInfoHUD = projectInfoHUD;
    }

    string url;

    public void InitContent(VideoFile videoFile)
    {
        thumbnail.sprite = videoFile.thumbnail;
        url = videoFile.url;

        playButton.onClick.AddListener(() =>
        {
            PlayVideo();
        });
    }

    public void PlayVideo()
    {
        VideoPlayerManager videoPlayer = PortfolioManager.Instance.GetVideoPlayer();

        if(videoPlayer != null)
        {
            myProjectInfoHUD.onAnyContentPlayed?.Invoke(true);
            videoPlayer.self.SetLocalXY(0, 0);
            videoPlayer.transform.SetParent(contentParent);
            videoPlayer.transform.localScale = Vector3.one;
            videoPlayer.transform.rotation = Quaternion.identity;
            videoPlayer.gameObject.SetActive(true);

            videoPlayer.InitVideo(url);
        }
    }
}
