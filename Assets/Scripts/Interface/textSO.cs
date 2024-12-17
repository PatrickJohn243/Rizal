using UnityEngine;

[CreateAssetMenu(menuName = "Texts/text")]
public class textSO : ScriptableObject
{
    [TextArea(3, 10)]
    public string text;
}
