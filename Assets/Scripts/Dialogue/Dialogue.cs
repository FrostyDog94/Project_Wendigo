using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Dialogue/Dialogue")]
public class Dialogue : ScriptableObject
{
    public string speaker;
    [TextArea(3,8)]
    public string[] lines;
}
