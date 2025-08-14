using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    [Header("ELEMENTS")]
    [SerializeField] VideoPlayer videoPlayer;

    public RectTransform self;

    public event System.Action OnVideoCompleted; // Optional: your own event

    public void InitVideo(string url)
    {
        if (!UrlHelper.IsValidUrl(url))
        {
            Debug.LogWarning($"Invalid video URL: {url}");
            return;
        }

        // Subscribe to completion event
        videoPlayer.loopPointReached += HandleVideoCompleted;

        StartCoroutine(LoadAndPlay(url));
    }

    private IEnumerator LoadAndPlay(string url)
    {
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = url;
        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared)
            yield return null;

        Debug.Log("Video prepared, playing...");
        videoPlayer.Play();
    }

    private void HandleVideoCompleted(VideoPlayer vp)
    {
        // Verify if the video really ended
        if (vp.frame >= (long)vp.frameCount - 1 ||
            Mathf.Abs((float)vp.time - (float)vp.length) < 0.1f)
        {
            Debug.Log("Video completed!");
            OnVideoCompleted?.Invoke();
            PortfolioManager.Instance.ReturnVideoPlayer();
        }
        else
        {
            Debug.Log("loopPointReached triggered but video not actually ended (likely buffering). Ignoring.");
        }
    }

    public bool IsPlaying()
    {
        return videoPlayer.isPlaying;
    }

    public void StopVideo()
    {
        videoPlayer.Stop();
        videoPlayer.loopPointReached -= HandleVideoCompleted; // Cleanup
    }
}
