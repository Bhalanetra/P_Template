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

    /// <summary>
    /// Opens the default email app in compose mode.
    /// Works on PC, Web, and Mobile.
    /// </summary>
    /// <param name="to">Recipient email address</param>
    /// <param name="subject">Subject of the email</param>
    /// <param name="body">Body of the email</param>
    public static void ComposeEmail(string to, string subject = "", string body = "")
    {
        if (string.IsNullOrEmpty(to))
        {
            Debug.LogError("Recipient email address is required.");
            return;
        }

        // Encode subject & body to make them URL safe
        string escapedSubject = Uri.EscapeDataString(subject);
        string escapedBody = Uri.EscapeDataString(body);

        // Build mailto URL
        string mailto = $"mailto:{to}?subject={escapedSubject}&body={escapedBody}";

#if UNITY_WEBGL && !UNITY_EDITOR
        // For WebGL: open in a new browser tab
        Application.ExternalEval($"window.open('{mailto}', '_blank')");
#else
        // For PC & Mobile
        Application.OpenURL(mailto);
#endif
    }

    public enum WebMailService
    {
        Default, // mailto:
        Gmail,
        Outlook
    }

    public static void ComposeEmail(string to, string subject = "", string body = "", WebMailService webMailService = WebMailService.Default)
    {
        if (string.IsNullOrEmpty(to))
        {
            Debug.LogError("Recipient email address is required.");
            return;
        }

        string escapedSubject = Uri.EscapeDataString(subject);
        string escapedBody = Uri.EscapeDataString(body);

#if UNITY_WEBGL && !UNITY_EDITOR
        string url;

        switch (webMailService)
        {
            case WebMailService.Gmail:
                url = $"https://mail.google.com/mail/?view=cm&fs=1&to={to}&su={escapedSubject}&body={escapedBody}";
                break;
            case WebMailService.Outlook:
                url = $"https://outlook.live.com/mail/deeplink/compose?to={to}&subject={escapedSubject}&body={escapedBody}";
                break;
            default:
                url = $"mailto:{to}?subject={escapedSubject}&body={escapedBody}";
                break;
        }

        Application.ExternalEval($"window.open('{url}', '_blank')");
#else
        string mailto = $"mailto:{to}?subject={escapedSubject}&body={escapedBody}";
        Application.OpenURL(mailto);
#endif
    }
}
