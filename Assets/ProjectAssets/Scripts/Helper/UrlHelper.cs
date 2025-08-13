using UnityEngine;
using System;

public static class UrlHelper
{
    public static bool IsValidUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            return false;

        if (Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult))
        {
            return uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps;
        }

        return false;
    }

    public static void OpenUrl(string url)
    {
        if (!IsValidUrl(url))
        {
            Debug.LogWarning($"Invalid URL: {url}");
            return;
        }

#if UNITY_WEBGL && !UNITY_EDITOR
        // WebGL: open in new tab
        Application.ExternalEval($"window.open('{url}', '_blank')");
#else
        // Mobile & Standalone: open default browser
        Application.OpenURL(url);
#endif
    }
}
