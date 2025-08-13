
using TMPro;
using UnityEngine;

public class Experiance_HUD : PoolableObject
{
    [Header("ELEMENTS")]
    [SerializeField] TextMeshProUGUI companyNameText;
    [SerializeField] TextMeshProUGUI DOJ_Text;
    [SerializeField] TextMeshProUGUI DOE_Text;
    [SerializeField] TextMeshProUGUI descText;

    private const string DOJ_default = "DOJ : ";
    private const string DOE_default = "DOE : ";

    public void ApplyContent(WorkExperiance workExperiance)
    {
        companyNameText.text = workExperiance.companyName;
        DOJ_Text.text = DOJ_default + workExperiance.joiningDate.GetDateString();

        string doeText;

        if (workExperiance.presentlyWorking)
        {
            doeText = DOE_default + "PRESENT";
        }
        else
        {
            doeText = DOE_default + workExperiance.relievingDate.GetDateString();
        }

        DOE_Text.text = doeText;

        descText.text = workExperiance.responsibilities;
    }
}
