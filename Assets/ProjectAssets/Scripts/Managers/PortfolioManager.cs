using UnityEngine;

public class PortfolioManager : MonoBehaviour
{
    [Space, Header("PORTFOLIO")]
    public AboutMe_Content aboutMe;
    public Skill_Content skills;
    public Projects_Content projects;
    public WorkExperience_Content experience;
    public Qualifications_Content qualifications;
    public Contacts_Content contactInfo;

    public void LoadProfile()
    {
        LoadAboutMe(aboutMe);
        LoadSkills(skills);
        LoadProjects(projects);
        LoadExperiance(experience);
        LoadQualifications(qualifications);
        LoadContactInfo(contactInfo);
    }

    void LoadAboutMe(AboutMe_Content aboutMe)
    {
        if (aboutMe == null)
        {
            Debug.LogError("Main Content Missing !");
            return;
        }
    }
    void LoadSkills(Skill_Content skills)
    {
        if (!skills) return;
    }

    void LoadProjects(Projects_Content projects)
    {
        if(!projects) return;
    }

    void LoadExperiance(WorkExperience_Content experience)
    {
        if (experience == null) return;
    }

    void LoadQualifications(Qualifications_Content qualifications)
    {
        if(qualifications == null) return;
    }

    void LoadContactInfo(Contacts_Content contactInfo)
    {
        if(contactInfo == null) return;
    }
}
