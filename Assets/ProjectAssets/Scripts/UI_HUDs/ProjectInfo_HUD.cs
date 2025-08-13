using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProjectInfo_HUD : PoolableObject
{
    [Header("ELEMENTS")]

    [Space, Header("Graphics")]
    [SerializeField] RectTransform graphicParent;
    [SerializeField] Button nextSlideButton;
    [SerializeField] Button prevSlideButton;

    [Space, Header("Details")]
    [SerializeField] TextMeshProUGUI projectNameText;
    [SerializeField] TextMeshProUGUI projectDescText;

    [Space, Header("Link")]
    [SerializeField] Button projectLinkButton;

    private string projectURL;

    public List<GameObject> graphicContents = new List<GameObject>();

    public void ApplyContent(Project project)
    {
        projectNameText.text = project.projectName;
        projectDescText.text = project.description;



        if(!string.IsNullOrEmpty(project.url) && UrlHelper.IsValidUrl(project.url))
        {
            projectURL = project.url;
            projectLinkButton.onClick.AddListener(() =>
            {
                UrlHelper.OpenUrl(projectURL);
            });

            projectLinkButton.interactable = true;
        }
        else
        {
            projectLinkButton.interactable = false;
        }
    }
}
