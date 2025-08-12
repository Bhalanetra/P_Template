using UnityEngine;

[CreateAssetMenu(fileName = "ContentBase", menuName = "P-Template/Content/ContentBase")]
public abstract class ContentBase : ScriptableObject
{
    public abstract ContentCategory contentType { get; }
}
