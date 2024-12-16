using UnityEngine;

public enum InteractableType
{
    letter,
    relic
}

[CreateAssetMenu(menuName = "Interactables/interactables")]
public class InteractableConfig : ScriptableObject
{
    public Sprite promptImage;
    public InteractableType interactableType;
}