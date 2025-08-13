using UnityEngine;

public class PortfolioManager : MonoBehaviour
{
    [Space, Header("PORTFOLIO")]

    [Space, Header("CONTENT")]
    public AboutMe_Content aboutMe;
    public Skill_Content skills;
    public Projects_Content projects;
    public WorkExperience_Content experience;
    public Qualifications_Content qualifications;
    public Contacts_Content contactInfo;

    [Space]
    public Containers containers;

    private void Start()
    {
        LoadProfile();
    }

    public void LoadProfile()
    {
        LoadAboutMe(aboutMe);
        LoadSkills(skills);
        LoadProjects(projects);
        LoadExperiance(experience);
        LoadContactInfo(contactInfo);
    }

    void LoadAboutMe(AboutMe_Content aboutMe)
    {
        if (aboutMe == null)
        {
            Debug.LogError("Main Content Missing !");
            return;
        }

        LoadContainerData(aboutMe);
    }
    void LoadSkills(Skill_Content skills)
    {
        if (!skills) return;

        LoadContainerData(skills);
    }

    void LoadProjects(Projects_Content projects)
    {
        if(!projects) return;

        LoadContainerData(projects);
    }

    void LoadExperiance(WorkExperience_Content experience)
    {
        if (experience == null) return;

        LoadContainerData(experience);
    }

    void LoadQualifications(Qualifications_Content qualifications)
    {
        if(qualifications == null) return;

        LoadContainerData(qualifications);
    }

    void LoadContactInfo(Contacts_Content contactInfo)
    {
        if(contactInfo == null) return;

        LoadContainerData(contactInfo);
    }

    void LoadContainerData(ContentBase contentBase)
    {
        ContentContainerBase container = containers.GetContainer(contentBase.contentType);

        container.InitializeContent(contentBase);
    }
}
