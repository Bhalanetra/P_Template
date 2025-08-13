using System;
using UnityEngine;

public class SerializableClasses
{
}

[Serializable]
public class Skill
{
    public string skillName;
    public Sprite logo;
    public SubSkill[] subSkills;
}

[Serializable]
public class SubSkill
{
    public string subSkillName;
    public Sprite icon;
}

[Serializable]
public class Project
{
    public string projectName;
    public Sprite[] images;
    public VideoFile[] videoFiles;
    [TextArea]
    public string description;
    public string url;
}

[Serializable]
public class WorkExperiance
{
    public string companyName;

    [Space]
    public Date joiningDate;
    [Space]
    public bool presentlyWorking = false;
    public Date relievingDate;

    [TextArea]
    public string responsibilities;
}

[Serializable]
public class Qualification
{
    public string qualificationOrCertificationName;
    public string instituteName;
    public int passedYear;
}

[Serializable]
public class ContactInfo
{
    public Sprite socialIcon;
    public string socialName;
    public string contactUrl;
}

[Serializable]
public class Date
{
    public string year; public string month; public string day;

    public string GetDateWithDayString()
    {
        string date = $"{day}/{month}/{year}";

        return date;
    }

    public string GetDateString()
    {
        string date = $"{month}/{year}";

        return date;
    }
}

public enum ContentCategory
{
    ABOUT_ME,
    SKILLS,
    PROJECTS,
    EXPERIENCE,
    QUALIFICATION,
    CONTACT_INFO
}

[Serializable]
public class VideoFile
{
    public Sprite thumbnail;
    public string url;
}

[Serializable]
public class Containers
{
    [SerializeField] AboutMe_Container aboutMe_Container;
    [SerializeField] Skills_Container skills_Container;
    [SerializeField] Projects_Container projects_Container;
    [SerializeField] Experiance_Container experiance_Container;
    [SerializeField] ContactInfo_Container contactInfo_Container;

    public ContentContainerBase GetContainer(ContentCategory category)
    {
        switch (category)
        {
            case ContentCategory.ABOUT_ME:

                return aboutMe_Container;

            case ContentCategory.SKILLS:

                return skills_Container;

            case ContentCategory.PROJECTS:

                return projects_Container;

            case ContentCategory.EXPERIENCE:

                return experiance_Container;

            case ContentCategory.QUALIFICATION:

                return aboutMe_Container;

            case ContentCategory.CONTACT_INFO:

                return contactInfo_Container;

        }

        return null;
    }
}
