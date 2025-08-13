using UnityEngine;
using UnityEngine.UI;

public class VideoContentAndPlayer : PoolableObject
{
    [Header("ELEMENTS")]
    [SerializeField] Image thumbnail;
    [SerializeField] Button playButton;

    [Space]
    [SerializeField] RectTransform contentParent;

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
            videoPlayer.transform.SetParent(contentParent);
            videoPlayer.transform.localScale = Vector3.one;
            videoPlayer.transform.rotation = Quaternion.identity;
            videoPlayer.gameObject.SetActive(true);
        }
    }
}
