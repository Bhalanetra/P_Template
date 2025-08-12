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
    public string[] tools;
    public string[] tasks;
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

    [Space]
    public string[] responsibilities;
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
    public string contactName;
    public string contactUrl;
}

[Serializable]
public class Date
{
    public string year; public string month; public string day;
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
