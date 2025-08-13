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
        PoolableObject poolObject = PoolManager.Instance.SpawnFromPool("VideoPlayer", contentParent, Quaternion.identity);

        if(poolObject.TryGetComponent(out VideoPlayerManager videoPlayerManager))
        {
            videoPlayerManager.InitVideo(url);
        }
    }
}
