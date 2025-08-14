using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProjectInfo_HUD : PoolableObject
{
    [Header("ELEMENTS")]
    [SerializeField] Project projectDetails;

    [Space, Header("Graphics")]
    [SerializeField] RectTransform graphicParent;
    [SerializeField] Button nextSlideButton;
    [SerializeField] Button prevSlideButton;

    [Space, Header("Details")]
    [SerializeField] TextMeshProUGUI projectNameText;
    [SerializeField] TextMeshProUGUI projectDescText;

    [Space, Header("Link")]
    [SerializeField] Button projectLinkButton;

    [Header("Settings")]
    public float autoScrollDelay = 3f; // seconds
    public bool autoScroll = true;

    private Coroutine autoScrollRoutine;

    private string projectURL;

    public int currentContentIndex = 0;
    public List<GameObject> graphicContents = new List<GameObject>();

    public Action<bool> onAnyContentPlayed;

    public void ApplyContent(Project project)
    {
        graphicContents.Clear();

        projectDetails = new Project();
        projectDetails = project;

        projectNameText.text = projectDetails.projectName;
        projectDescText.text = projectDetails.description;

        if(projectDetails.images != null && projectDetails.images.Length > 0)
        {
            foreach(Sprite image in projectDetails.images)
            {
                PoolableObject imageObject = PoolManager.Instance.SpawnFromPool("ImageContent_HUD", graphicParent, Quaternion.identity);

                if(imageObject.TryGetComponent(out ImageContent imageContent))
                {
                    imageContent.SetProjectHUD(this);
                    imageContent.ApplyImage(image);

                    imageContent.self.SetLocalXY(0, 0);

                    graphicContents.Add(imageContent.gameObject);
                }
            }
        }

        if(projectDetails.videoFiles != null &&  projectDetails.videoFiles.Length > 0)
        {
            foreach (VideoFile videoFile in projectDetails.videoFiles)
            {
                PoolableObject videoObject = PoolManager.Instance.SpawnFromPool("VideoContent_HUD", graphicParent, Quaternion.identity);

                if (videoObject.TryGetComponent(out VideoContentAndPlayer videoContent))
                {
                    videoContent.SetProjectHUD(this);
                    videoContent.InitContent(videoFile);

                    videoContent.self.SetLocalXY(0, 0);

                    graphicContents.Add(videoContent.gameObject);
                }
            }
        }

        if(graphicContents.Count > 0)
        {
            nextSlideButton.gameObject.SetActive(true);
            prevSlideButton.gameObject.SetActive(true);
        }
        else
        {
            nextSlideButton.gameObject.SetActive(false);
            prevSlideButton.gameObject.SetActive(false);
        }


        if(!string.IsNullOrEmpty(projectDetails.url) && UrlHelper.IsValidUrl(projectDetails.url))
        {
            projectURL = projectDetails.url;
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

    private void OnEnable()
    {
        LoadContent();

        onAnyContentPlayed += OnAnyContentPlayed;
    }

    private void OnDisable()
    {
        onAnyContentPlayed -= OnAnyContentPlayed;
    }

    void OnAnyContentPlayed(bool played)
    {
        if (played)
        {
            if(autoScrollRoutine != null) StopCoroutine(autoScrollRoutine);
        }
        else
        {
            if(autoScrollRoutine == null) StartCoroutine(AutoScroll());
        }
    }

    private void LoadContent()
    {
        // Assign button events
        if (nextSlideButton) nextSlideButton.onClick.AddListener(NextContent);
        if (prevSlideButton) prevSlideButton.onClick.AddListener(PrevContent);

        ShowContent(currentContentIndex);

        if (autoScroll)
            autoScrollRoutine = StartCoroutine(AutoScroll());
    }

    private void ShowContent(int index)
    {
        if (graphicContents.Count == 0) return;

        for (int i = 0; i < graphicContents.Count; i++)
            graphicContents[i].SetActive(i == index);

        PortfolioManager manager = PortfolioManager.Instance;

        if(manager.videoPlayerManager.IsPlaying())
        {
            manager.ReturnVideoPlayer();
        }
    }

    public void NextContent()
    {
        if (graphicContents.Count == 0) return;

        currentContentIndex++;
        if (currentContentIndex >= graphicContents.Count) currentContentIndex = 0; // loop
        ShowContent(currentContentIndex);
    }

    public void PrevContent()
    {
        if (graphicContents.Count == 0) return;

        currentContentIndex--;
        if (currentContentIndex < 0) currentContentIndex = graphicContents.Count - 1; // loop
        ShowContent(currentContentIndex);
    }

    private IEnumerator AutoScroll()
    {
        while (true)
        {
            yield return new WaitForSeconds(autoScrollDelay);
            NextContent();
        }
    }
}
