using UnityEngine;

public interface IInteractable
{
    void Interact(int itemInteractedCase);
    InteractableConfig GetInteractableConfig();
}
