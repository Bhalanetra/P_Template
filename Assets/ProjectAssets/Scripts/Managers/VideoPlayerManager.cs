using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    [Header("ELEMENTS")]
    [SerializeField] VideoPlayer videoPlayer;

    public void InitVideo(string url)
    {
        if (!UrlHelper.IsValidUrl(url))
        {
            Debug.LogWarning($"Invalid video URL: {url}");
            return;
        }

        StartCoroutine(LoadAndPlay(url));
    }

    private IEnumerator LoadAndPlay(string url)
    {
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = url;
        videoPlayer.Prepare();

        // Wait until video is prepared
        while (!videoPlayer.isPrepared)
            yield return null;

        Debug.Log("Video prepared, playing...");
        videoPlayer.Play();
    }
}
